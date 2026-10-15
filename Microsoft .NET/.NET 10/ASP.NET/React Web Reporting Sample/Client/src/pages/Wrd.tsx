/*
 * D:   Der WebReportDesigner wird bewusst als iFrame eingebunden und nicht direkt als Custom
 *      Element auf diese Seite gesetzt. Grund ist nicht die Groesse, sondern der Zustand:
 *
 *      Das Skript WebReportDesigner.js haelt seine Sitzung (u.a. die InstanceID, die als
 *      X-Instance-Header an den Server geht) im Modul-Zustand - also im Skript, nicht am Element.
 *      Wird das Element beim Navigieren entfernt und spaeter neu erzeugt, haengt es sich wieder
 *      an dieselbe, serverseitig laengst geschlossene Instanz. Der erste Zugriff auf instance.Ll
 *      endet dann in einer NullReferenceException (GetMultipleSVGs) - der Bericht laesst sich erst
 *      nach "Projekt neu laden" wieder oeffnen.
 *
 *      Ein iFrame loest das strukturell: beim Navigieren stirbt der komplette JavaScript-Kontext
 *      des Frames, beim Zurueckkehren entsteht ein neuer - mit neuer InstanceID und damit einer
 *      frischen Serverinstanz.
 *
 *      Sobald die Webkomponente ihren Sitzungszustand beim disconnectedCallback zuruecksetzt,
 *      kann der iFrame entfallen und das Element direkt hier stehen.
 * US:  The WebReportDesigner is deliberately embedded as an iFrame instead of putting the custom
 *      element directly on this page. The reason is not sizing but state:
 *
 *      The WebReportDesigner.js script keeps its session (including the InstanceID that is sent to
 *      the server as the X-Instance header) in module state - in the script, not on the element.
 *      If the element is removed on navigation and re-created later, it reattaches to the same,
 *      server-side long since closed instance. The first access to instance.Ll then ends in a
 *      NullReferenceException (GetMultipleSVGs) - the report can only be opened again after
 *      "reload project".
 *
 *      An iFrame solves this structurally: navigating away destroys the frame's entire JavaScript
 *      context, coming back creates a new one - with a new InstanceID and therefore a fresh server
 *      instance.
 *
 *      As soon as the web component resets its session state in disconnectedCallback, the iFrame
 *      can be dropped and the element placed directly here.
 */
export function Wrd() {
  return <iframe className="component-frame" src="/wrd-frontend" title="Web Report Designer" />;
}
