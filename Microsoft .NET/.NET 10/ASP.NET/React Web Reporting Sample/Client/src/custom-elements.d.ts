/**
 * TypeScript declarations for List & Label web components (custom elements).
 * These are rendered by the WebReportDesigner.js / WebReportViewer.js scripts.
 *
 * NOTE: since React 19 / @types/react 19 the global JSX namespace no longer exists.
 * Custom elements have to be declared by augmenting the JSX namespace inside the
 * "react" module - a plain `declare namespace JSX` is silently ignored, which makes
 * every custom element an "does not exist on type 'JSX.IntrinsicElements'" error.
 * The import below is what turns this file into a module so the augmentation applies.
 */
import "react";

declare module "react" {
  namespace JSX {
    interface IntrinsicElements {
      "ll-webreportdesigner": React.DetailedHTMLProps<
        React.HTMLAttributes<HTMLElement> & {
          backendurl?: string;
          defaultProject?: string;
          showTutorial?: boolean;
          auth_type?: string;
          auth_token?: string;
        },
        HTMLElement
      >;
      "ll-webreportviewer": React.DetailedHTMLProps<
        React.HTMLAttributes<HTMLElement> & {
          backendurl?: string;
          defaultProject?: string;
        },
        HTMLElement
      >;
    }
  }
}
