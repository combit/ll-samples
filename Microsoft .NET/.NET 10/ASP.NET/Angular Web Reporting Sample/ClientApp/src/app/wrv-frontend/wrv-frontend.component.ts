import { Component, CUSTOM_ELEMENTS_SCHEMA, OnInit, signal } from '@angular/core';

/*
 * D:   Diese Seite wird nur innerhalb des iFrames von /viewer angezeigt und traegt die
 *      eigentliche Webkomponente. Zu den Signals siehe wrd-frontend.component.ts.
 * US:  This page is only shown inside the iFrame of /viewer and carries the actual web component.
 *      For the signals see wrd-frontend.component.ts.
 */
@Component({
  selector: 'app-wrv-frontend',
  standalone: true,
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  templateUrl: './wrv-frontend.component.html',
  styleUrl: './wrv-frontend.component.css'
})
export class WrvFrontendComponent implements OnInit {
  readonly backendBaseUrl = 'https://localhost:7147';
  readonly backendUrl = `${this.backendBaseUrl}/LLWebReportViewer`;

  // D:   Der im Designer gewaehlte Bericht, sonst der Standardbericht - der Viewer braucht immer
  //      etwas anzuzeigen. Siehe DefaultSettings.ViewerProject.
  // US:  The report selected in the designer, otherwise the default report - the viewer always
  //      needs something to display. See DefaultSettings.ViewerProject.
  readonly defaultProject = signal<string | undefined>(undefined);
  readonly ready = signal(false);

  async ngOnInit(): Promise<void> {
    try {
      const response = await fetch(`${this.backendBaseUrl}/api/sample/defaults`);
      const defaults = await response.json();
      this.defaultProject.set(defaults.viewerProject || undefined);
    } catch {
      this.defaultProject.set(undefined);
    }
    this.ready.set(true);
  }
}
