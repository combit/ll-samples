import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'List & Label Web Reporting';

  // D:   Die *-frontend-Routen werden ausschliesslich im iFrame angezeigt. Dort waere die
  //      Kopfzeile ein zweites Mal zu sehen, deshalb wird sie dort ausgeblendet.
  // US:  The *-frontend routes are only ever displayed inside the iFrame. The header would appear
  //      a second time there, so it is hidden on those routes.
  showChrome = true;

  constructor(router: Router) {
    router.events
      .pipe(filter((event): event is NavigationEnd => event instanceof NavigationEnd))
      .subscribe(event => this.showChrome = !event.urlAfterRedirects.includes('-frontend'));
  }
}
