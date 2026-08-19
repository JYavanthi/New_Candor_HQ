import { Component, HostListener, Input } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-common-asset',
  templateUrl: './common-asset.component.html',
  styleUrls: ['./common-asset.component.css', '../assetmodule.css']
})
export class CommonAssetComponent {
  showBackIcon: boolean = false;
  currentUrl: any;
  assetId: any;
  assetData: any;
  selectedTabIndex: number = 0;
  disableResolution: boolean = false;
  isAsset = true

  constructor(public httpSer: HttpServiceService,
    public activeRoute: ActivatedRoute,
    private location: Location,
    public router: Router) {
    this.currentUrl = this.router.url.split('?')[0];

    this.activeRoute.queryParams.subscribe((m: any) => {
      this.assetId = m.assetid;
      if (this.assetId) {
        this.getData();
      }
    });
  }

  ngOnInit() {
  }

  serviceTitlesWithAPI: { [key: string]: { title: string, apiUrl: string } } = {
    '/assets/itspare': { title: 'IT Spare', apiUrl: '/ITSpareRequest/GetSpareById' },
    '/assets/itasset': { title: 'IT Asset', apiUrl: '/AssetRequest/AssetbyID' }
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.showBackIcon = window.scrollY > 200;
  }

  navigateToBack() {
    this.location.back();
  }

  getTitle(): string {
    const assetInfo = this.serviceTitlesWithAPI[this.currentUrl];
    const baseTitle = assetInfo ? assetInfo.title : 'Asset';
    return this.assetId ? `Update ${baseTitle}` : baseTitle;
  }

  getData() {
    const assetInfo = this.serviceTitlesWithAPI[this.currentUrl];
    if (assetInfo) {
      const apiUrl = assetInfo.apiUrl;
      this.httpSer.httpGet(apiUrl, { 'ID': this.assetId }).subscribe((res: any) => {
        this.assetData = res.data;
        console.log('this.assetData', this.assetData)
      });
    } else {
    }
  }
}
