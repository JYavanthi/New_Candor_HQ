import { addClass, removeClass, Browser } from '@syncfusion/ej2-base';
import {
  RichTextEditor,
  Toolbar,
  PasteCleanup,
  Link,
  Image,
  Count,
  HtmlEditor,
  QuickToolbar,
  Table,
  FileManager,
} from '@syncfusion/ej2-richtexteditor';
RichTextEditor.Inject(
  Toolbar,
  Link,
  Image,
  PasteCleanup,
  Count,
  HtmlEditor,
  QuickToolbar,
  Table,
  FileManager
);
import 'codemirror/mode/javascript/javascript';
import 'codemirror/mode/css/css.js';
import 'codemirror/mode/htmlmixed/htmlmixed.js';

let hostUrl: string = 'https://ej2-aspcore-service.azurewebsites.net/';
let defaultRTE: RichTextEditor = new RichTextEditor({
  enterKey: 'BR',
});
defaultRTE.appendTo('#defaultRTE');
