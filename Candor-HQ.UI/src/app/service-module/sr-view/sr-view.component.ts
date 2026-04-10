import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-sr-view',
  templateUrl: './sr-view.component.html',
  styleUrl: './sr-view.component.css'
})
export class SrViewComponent {
  constructor(private location: Location) { }

  // viewServices: any[] = [
  //   { 'routerLink': '/services/software', 'iconClass': 'assets/image/computer.png', 'iconColor': '#7743e8', 'serviceTitle': 'Software' },
  //   { 'routerLink': '/services/domain', 'iconClass': 'fa fa-globe', 'iconColor': '#4dd3da', 'serviceTitle': 'Domain' },
  //   { 'routerLink': '/services/email', 'iconClass': 'fa fa-envelope', 'iconColor': '#f78204', 'serviceTitle': 'Email' },
  //   { 'routerLink': '/services/externaldriveaccess', 'iconClass': 'fa fa-hdd-o', 'iconColor': '#029695', 'serviceTitle': 'External Drive Access' },
  //   { 'routerLink': '/services/ftpaccess', 'iconClass': 'fa fa-cloud-upload', 'iconColor': '#f58c99', 'serviceTitle': 'FTP Access' },
  //   { 'routerLink': '/services/usbaccess', 'iconClass': 'fa fa-usb', 'iconColor': '#da523a', 'serviceTitle': 'USB Access' },
  //   { 'routerLink': '/services/windowslogin', 'iconClass': 'fa fa-windows', 'iconColor': '#04b6e4', 'serviceTitle': 'Windows Login' },
  //   { 'routerLink': '/services/citrixaccess', 'iconClass': 'fa fa-user-secret', 'iconColor': '#5dd9e6', 'serviceTitle': 'Citrix Access' },
  //   { 'routerLink': '/services/vpnaccess', 'iconClass': 'fa fa-link', 'iconColor': '#3ac059', 'serviceTitle': 'VPN Access' },
  //   { 'routerLink': '/services/urlorinternetaccess', 'iconClass': 'fa fa-desktop', 'iconColor': '#7fb019', 'serviceTitle': 'URL/Internet Access' },
  //   { 'routerLink': '/services/wifiaccess', 'iconClass': 'fa fa-wifi', 'iconColor': '#a5cc82', 'serviceTitle': 'Wifi Access' },
  //   { 'routerLink': '/services/fileserveroraccessforfolderaccess', 'iconClass': 'fa fa-folder-open', 'iconColor': '#f7d367', 'serviceTitle': 'File Server/ Access For Folders' },
  //   { 'routerLink': '/services/backuprestoration', 'iconClass': 'fa fa-database', 'iconColor': '#c8c8c9', 'serviceTitle': 'Backup & Restoration' },
  //   { 'routerLink': '/services/remoteaccess', 'iconClass': 'fa fa-asterisk', 'iconColor': '#f75421', 'serviceTitle': 'Remote Access' },
  //   { 'routerLink': '/services/antivirus', 'iconClass': 'fa fa-shield', 'iconColor': '#77bf4f', 'serviceTitle': 'Antivirus' },
  //   { 'routerLink': '/services/virtualmeeting', 'iconClass': 'fa fa-comments-o', 'iconColor': '#f671a4', 'serviceTitle': 'Virtual Meeting' }
  // ]


  viewServices: any[] = [
    { routerLink: '/services/software', iconImage: 'assets/image/computer.png', serviceTitle: 'Software' },
    { routerLink: '/services/domain', iconImage: 'assets/image/domain.png', serviceTitle: 'Domain' },
    { routerLink: '/services/email', iconImage: 'assets/image/email.png', serviceTitle: 'Email' },
    { routerLink: '/services/externaldriveaccess', iconImage: 'assets/image/external_drive.png', serviceTitle: 'External Drive Access' },
    { routerLink: '/services/ftpaccess', iconImage: 'assets/image/ftp.png', serviceTitle: 'FTP Access' },
    { routerLink: '/services/usbaccess', iconImage: 'assets/image/usb.png', serviceTitle: 'USB Access' },
    { routerLink: '/services/windowslogin', iconImage: 'assets/image/windows.png', serviceTitle: 'Windows Login' },
    { routerLink: '/services/citrixaccess', iconImage: 'assets/image/citrix.png', serviceTitle: 'Citrix Access' },
    { routerLink: '/services/vpnaccess', iconImage: 'assets/image/vpn.png', serviceTitle: 'VPN Access' },
    { routerLink: '/services/urlorinternetaccess', iconImage: 'assets/image/internet.png', serviceTitle: 'URL/Internet Access' },
    { routerLink: '/services/wifiaccess', iconImage: 'assets/image/wifi.png', serviceTitle: 'Wifi Access' },
    { routerLink: '/services/fileserveroraccessforfolderaccess', iconImage: 'assets/image/folder.png', serviceTitle: 'File Server/ Access For Folders' },
    { routerLink: '/services/backuprestoration', iconImage: 'assets/image/backup.png', serviceTitle: 'Backup & Restoration' },
    { routerLink: '/services/remoteaccess', iconImage: 'assets/image/remote.png', serviceTitle: 'Remote Access' },
    { routerLink: '/services/antivirus', iconImage: 'assets/image/antivirus.png', serviceTitle: 'Antivirus' },
    { routerLink: '/services/virtualmeeting', iconImage: 'assets/image/meeting.png', serviceTitle: 'Virtual Meeting' }
  ];

}
