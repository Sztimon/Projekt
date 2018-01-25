import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { Vehicle } from './vehicle.model';
import { Observable } from 'rxjs/Observable';



@Injectable()
export class VehicleService {
    private vehicles: Vehicle[];
    headers: Headers;
    link: string;

    constructor(private http: Http) { }
    getVehicles(): Observable<Vehicle[]> {
        return this.http.get('/api/vehicles').map(res => {
            this.vehicles = <Vehicle[]>res.json();
            this.vehicles.slice();
            this.vehicles.sort((a, b): number => {

                if (a.counter > b.counter) return -1;
                if (a.counter < b.counter) return 1;
                return 0;
            });
             return this.vehicles;
        });
    }
    test() {
        return this.vehicles;
    }
    increaseCounter(vehicleId: number) {
        this.headers = new Headers({ 'Content-Type': 'application/json' });
        this.http.put('/api/vehicles/' + vehicleId + '/counter', '', new RequestOptions({ headers: this.headers })).subscribe();
    }
    deleteVehicle(id: number) {
        console.log('sending request')
        return this.http.delete('/api/vehicles/' + id, new RequestOptions({ headers: this.headers })).subscribe();
    }
    getMakes() {
        return this.http.get('/api/makes')
            .map(res => res.json());
    }

    getFeatures() {
        return this.http.get('api/features')
            .map(res => res.json());
    }

    createVehicle(vehicle) {
        
        return this.http.post('/api/vehicles', vehicle)
            .map(res => res.json());
    }

    updateVehicle(vehicle, id) {
        this.link = '/api/vehicles/' + id
        return this.http.put(this.link, vehicle)
            .map(res => res.json());
    }
}
