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

  ngOnInit(): void {
    this.parcelService.getParcel().subscribe((data:any) => {
      this.data = JSON.parse(data.details);
    })
  }

  getHeaders() {
    let headers: string[] = [];
    if(this.data) {
      this.data.forEach((value: string) => {
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
