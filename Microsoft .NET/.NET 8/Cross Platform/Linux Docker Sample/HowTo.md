# Linux Docker Sample for List & Label CrossPlatform 

Followed up you'll get a step-by-step description how to run the Linux Docker Sample on both Linux (Ubuntu) and Windows environments. 
The sample is a minimized .NET 8 Console application that creates a  report file from scratch using the [List & Label CrossPlatform DOM API](https://docu.combit.net/crossplatform/en/api/combit.Reporting.Dom.html) and then exports it to PDF format. 

### Requirements

- available Docker installation
- needed Fonts have to be installed (done via Dockerfile)
- Dependencies have to be installed (done via Dockerfile)
- *List & Label CrossPlatform* and *SkiaSharp.NativeAssets.Linux* NuGet Packages (via Solution)

### Installation
#### Linux
Use a terminal session to install Docker:
```
sudo apt update
sudo apt install docker.io -y
sudo systemctl start docker
sudo systemctl enable docker
```
##### Optional 
Add the current user to the Docker group
```
sudo usermod -aG docker $USER
```
Log out and log back in for the group change to take effect.

#### Windows
For Windows a setup file is avaible for Download:

[Download Docker Desktop](https://www.docker.com/products/docker-desktop/)

> Make sure that **WSL (Windows Subsystem for Linux) is available**. It can be activated running the setup. 

### Now let's Docker
#### Build the Docker image
Now run a new Terminal session in the folder of the sample and pass the following command to build the Docker image (**Dockerfile needed!**):

```
docker build -t llpdfgenerator .
```

#### Run the Docker container
After building the solution, the application can be executed by the following command:

###### Linux
```
docker run --rm -v "$PWD/export:/app/export" llpdfgenerator
```

##### Windows
```
docker run --rm -v "%cd%/export:/app/export" llpdfgenerator
```

The command additionally mounts a Docker volume called "export", which contains the generated List & Label CrossPlatform report file (report.json), a Debwin log file (report.log) and of course the exported PDF document (report.pdf).

### Troubleshooting
#### Error 

While executing the build step on **Linux** you are facing the following error:
> error: permission denied while trying to connect to the docker daemon socket at unix://var/run/docker.sock

#### Reason
It means that the current user does not have permission to access the Docker daemon. On Linux, Docker accesses the daemon via the Unix socket file ```/var/run/docker.sock``` by default, and this file belongs to the ```root``` user and the ```docker group```.

#### Solution #1
Run the commands with ```sudo```:
```
sudo docker build -t llpdfgenerator .
```
```
sudo docker run --rm -v "$PWD/export:/app/export" llpdfgenerator
```

#### Solution #2 
This can only be a solution if it is **NOT** already done via installing Docker (see chapter [Installation](#Installation))
1. Check whether the group ```docker``` is avaible:
    ```
    getent group docker
    ```
2. Add the user to the group ```docker``` is avaible:
    ```
    sudo usermod -aG docker $USER
    ```
3. Now log out and log back in for the group change to take effect.