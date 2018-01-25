import { Component, OnInit, Input } from '@angular/core';
import { Http, Response } from "@angular/http";
import { Observable } from 'rxjs';
import { LocationService } from '../../services/location.service';
import 'rxjs/add/operator/map';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
    private positionLat;
    private positionLng;
    response;
    constructor(private http: Http, private locationService: LocationService) { }
    ngOnInit() {
        this.locationService.getLocationsRequest().subscribe();

        if (window.navigator.geolocation) {
            window.navigator.geolocation.getCurrentPosition(position => {
                this.positionLat = position.coords.latitude;
                this.positionLng = position.coords.longitude;
            
                this.getNameOfLocalization(this.positionLat, this.positionLng);                    
            });
        }
    }
    getNameOfLocalization(lat: number, lng: number) {
        this.http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng=' + lat + ',' +
            lng + '&key=AIzaSyDLhNedmGIK6CPcxqEtQk_mPeko6QZ5his')
            .map(response => response.json())
            .subscribe(result => {
                this.response = result;

                this.retriveNameFromLocalization(result);
            });
    }
    retriveNameFromLocalization(location) {
        location.results[0].address_components.forEach(obj => {
            if (obj.types[0] === 'locality') {
                console.log(obj.long_name)
                this.locationService.addLocation(obj.long_name);
            }
        });
    }
}
