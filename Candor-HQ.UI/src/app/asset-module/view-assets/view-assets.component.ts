import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-view-assets',
  templateUrl: './view-assets.component.html',
  styleUrls: ['./view-assets.component.css', '../assetmodule.css']
})
export class ViewAssetsComponent {
  constructor(private location: Location){}

  // navigateToBack() {
  //   this.location.back();
  // }

}
