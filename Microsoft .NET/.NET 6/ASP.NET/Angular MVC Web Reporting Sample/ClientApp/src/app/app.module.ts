import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { WrdComponent } from './wrd/wrd.component';
import { WrvComponent } from './wrv/wrv.component';
import { WrdFrontendComponent } from './wrd-frontend/wrd-frontend.component';
import { WrvFrontendComponent } from './wrv-frontend/wrv-frontend.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    WrdComponent,
    WrvComponent,
    WrvFrontendComponent,
    WrdFrontendComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'wrd', component: WrdComponent },
      { path: 'wrv', component: WrvComponent },
      { path: 'wrd-frontend', component: WrdFrontendComponent },
      { path: 'wrv-frontend', component: WrvFrontendComponent },
    ])
  ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
