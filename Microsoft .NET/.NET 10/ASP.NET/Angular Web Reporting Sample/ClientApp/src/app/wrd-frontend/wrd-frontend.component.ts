import { Component, CUSTOM_ELEMENTS_SCHEMA, OnInit, signal } from '@angular/core';

/*
 * D:   Diese Seite wird nur innerhalb des iFrames von /designer angezeigt und traegt die
 *      eigentliche Webkomponente. Das Skript WebReportDesigner.js wird per <script>-Tag in
 *      index.html geladen; es wird zur Laufzeit aus der Assembly nach wwwroot extrahiert
 *      (siehe Program.cs) und muss daher nicht mitgeliefert werden.
 *
 *      Der Zustand liegt in Signals: der Wert wird nach einem await gesetzt, und natives
 *      async/await laeuft ausserhalb der Angular-Zone. Mit einem einfachen Feld wuerde die
 *      Ansicht daher nie aktualisiert - die Seite bliebe leer.
 * US:  This page is only shown inside the iFrame of /designer and carries the actual web
 *      component. The WebReportDesigner.js script is loaded via a <script> tag in index.html; it
 *      is extracted from the assembly into wwwroot at runtime (see Program.cs) and therefore need
 *      not be shipped.
 *
 *      State is held in signals: the value is set after an await, and native async/await runs
 *      outside the Angular zone. With a plain field the view would therefore never update - the
 *      page would stay blank.
 */
@Component({
  selector: 'app-wrd-frontend',
  standalone: true,
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  templateUrl: './wrd-frontend.component.html',
  styleUrl: './wrd-frontend.component.css'
})
export class WrdFrontendComponent implements OnInit {
  readonly backendBaseUrl = 'https://localhost:7147';
  readonly backendUrl = `${this.backendBaseUrl}/LLWebReportDesigner`;

  // D:   Zuletzt im Designer geoeffneter Bericht; beim ersten Start leer, dann zeigt der Designer
  //      seine eigene Auswahlseite. Siehe DefaultSettings.StartupProject.
  // US:  The report last opened in the designer; empty on first start, so the designer shows its
  //      own selection page. See DefaultSettings.StartupProject.
  readonly defaultProject = signal<string | undefined>(undefined);
  readonly ready = signal(false);

  async ngOnInit(): Promise<void> {
    // D:   Muss feststehen, bevor das Element eingehaengt wird - defaultProject wird nur beim
    //      Erzeugen des Elements ausgewertet.
    // US:  Must be settled before the element is mounted - defaultProject is only evaluated when
    //      the element is created.
    try {
      const response = await fetch(`${this.backendBaseUrl}/api/sample/defaults`);
      const defaults = await response.json();
      this.defaultProject.set(defaults.startupProject || undefined);
    } catch {
      this.defaultProject.set(undefined);
    }
    this.ready.set(true);
  }
}
