import { Component } from '@angular/core';

/*
 * D:   Wie beim Designer als iFrame eingebunden - siehe die ausfuehrliche Begruendung in
 *      wrd.component.ts. Beim Viewer kommt hinzu, dass sein Skript nach dem Entfernen des
 *      Elements noch laufende Rueckrufe hat, die das Element per document.querySelector wieder
 *      suchen. Stirbt der komplette Frame, kann das gar nicht erst passieren.
 * US:  Embedded as an iFrame like the designer - see the detailed reasoning in wrd.component.ts.
 *      For the viewer there is an additional reason: after the element is removed its script still
 *      has callbacks in flight that look the element up again via document.querySelector. If the
 *      whole frame dies, that cannot happen in the first place.
 */
@Component({
  selector: 'app-wrv',
  standalone: true,
  templateUrl: './wrv.component.html',
  styleUrl: './wrv.component.css'
})
export class WrvComponent { }
