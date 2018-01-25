import { Component, OnInit, OnDestroy } from '@angular/core';
import { VehicleService } from '../../../services/vehicle.service';
import { Vehicle } from '../../../services/vehicle.model';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit, OnDestroy {
    vehicles: Vehicle[];
    constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
      this.vehicleService.getVehicles().subscribe(res => this.vehicles = res);
      
  }
  ngOnDestroy() {
      this.vehicles.forEach(vehicle => {
      });
  }

}
