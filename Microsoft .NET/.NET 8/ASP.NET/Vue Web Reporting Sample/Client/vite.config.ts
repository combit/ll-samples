import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import fs from 'fs';
import path from 'path';
import child_process from 'child_process';

const baseFolder =
    process.env.APPDATA !== undefined && process.env.APPDATA !== ''
        ? `${process.env.APPDATA}/ASP.NET/https`
        : `${process.env.HOME}/.aspnet/https`;

// Check if the baseFolder exists
if (!fs.existsSync(baseFolder)) {
    try {
        // Create the baseFolder (recursive: true ensures intermediate directories are created)
        fs.mkdirSync(baseFolder, { recursive: true });
        console.log(`Created base folder: ${baseFolder}`);
    } catch (error) {
        console.error(`Error creating base folder: ${baseFolder}`, error);
    }
} else {
    console.log(`Base folder already exists: ${baseFolder}`);
}

const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
const certificateName = (certificateArg && certificateArg.groups) ? certificateArg.groups.value : "vueapp2.client";

if (!certificateName) {
    console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.')
    process.exit(-1);
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    if (0 !== child_process.spawnSync('dotnet', [
        'dev-certs',
        'https',
        '--export-path',
        certFilePath,
        '--format',
        'Pem',
        '--no-password',
    ], { stdio: 'inherit', }).status) {
        throw new Error("Could not create certificate.");
    }
}

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [vue({
        template: {
          compilerOptions: {
            isCustomElement: (tag) => ['ll-webreportdesigner', 'll-webreportviewer'].includes(tag),
          }
        }
      })],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        port: 3000,
        https: {
            key: fs.readFileSync(keyFilePath),
            cert: fs.readFileSync(certFilePath),
        }
    }
})
