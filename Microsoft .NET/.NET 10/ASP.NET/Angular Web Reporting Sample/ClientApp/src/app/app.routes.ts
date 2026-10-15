import { Routes } from '@angular/router';
import { WrdComponent } from './wrd/wrd.component';
import { WrvComponent } from './wrv/wrv.component';
import { WrdFrontendComponent } from './wrd-frontend/wrd-frontend.component';
import { WrvFrontendComponent } from './wrv-frontend/wrv-frontend.component';

/*
 * D:   Zwei Ebenen: /designer und /viewer sind die Seiten, die der Benutzer sieht. Sie binden
 *      /wrd-frontend bzw. /wrv-frontend als iFrame ein - dort liegen die eigentlichen
 *      List & Label-Webkomponenten. Warum, steht in wrd.component.ts.
 * US:  Two levels: /designer and /viewer are the pages the user sees. They embed /wrd-frontend
 *      and /wrv-frontend respectively as an iFrame - that is where the actual List & Label web
 *      components live. The reason is documented in wrd.component.ts.
 */
export const routes: Routes = [
  { path: '', redirectTo: 'designer', pathMatch: 'full' },
  { path: 'designer', component: WrdComponent },
  { path: 'viewer', component: WrvComponent },
  { path: 'wrd-frontend', component: WrdFrontendComponent },
  { path: 'wrv-frontend', component: WrvFrontendComponent }
];
