import { Component, OnInit } from '@angular/core';
import { ParcelService } from 'src/services/parcel.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  constructor(private parcelService : ParcelService ) {}

  title = 'TestApp';
  data: any;
  dataJson: any;

  ngOnInit(): void {
    this.parcelService.getParcelJson().subscribe((dataJson: any) => {
      this.dataJson = JSON.parse(dataJson.details);
    })
    this.parcelService.getParcel().subscribe((data: any) => {
      this.data = data;
    })
  }

  getHeaders(incomingData: any) {
    let headers: string[] = [];
    if(incomingData) {
      incomingData.forEach((value: string) => {
        Object.keys(value).forEach((key) => {
          if(!headers.find((header) => header == key)){
            headers.push(key)
          }
        })
      })
    }
    return headers;
  }
  
}
