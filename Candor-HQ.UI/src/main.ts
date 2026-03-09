/// <reference types="@angular/localize" />

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';import { environment } from '@environments/environment';
import { enableProdMode } from '@angular/core';
/*import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
*/platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

if (environment.production) {
  enableProdMode();
}
