import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ParcelService {
    constructor(private http: HttpClient) { }

    getParcel() {
        return this.http.get('https://localhost:7173/api/Parcel/GetParcel?ParcelNumber=0206202066')
    }
}