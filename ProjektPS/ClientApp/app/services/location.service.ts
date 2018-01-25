import { Injectable } from '@angular/core';
import { Location } from './location.model';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";

@Injectable()
export class LocationService  {
    private locations: Location[];
    headers: Headers;

    constructor(private http: Http) {
    }

    public getLocationsRequest(): Observable<Location[]> {
        return this.http.get('/api/vehicles/locations').map(res => {
            this.locations = <Location[]>res.json();
            this.locations.sort((a, b) => {
                if (a.counter > b.counter) return -1;
                if (a.counter < b.counter) return 1;
                return 0;
            })
            return this.locations.slice();
        });
    }
    public getLocations() {
        return this.locations;
    }
   
  public addLocation(name) {
         
      this.headers = new Headers({ 'Content-Type': 'application/json' });
      this.http.put('/api/vehicles/location/' + name, '', new RequestOptions({ headers: this.headers })).subscribe();
      
  }
  

}
