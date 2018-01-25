import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../../services/vehicle.service";

@Component({
  selector: 'app-edit-vehicle',
  templateUrl: './edit-vehicle.component.html',
  styleUrls: ['./edit-vehicle.component.css']
})
export class EditVehicleComponent implements OnInit {

    makes: any[];
    carModels: any[];
    features: any[];
    vehicle: any = {
        features: [],
        contact: {}
    };
    vehicles: any[];
    vehicleToChange: number;

    constructor(private vehicleService: VehicleService) { }

    ngOnInit() {
        this.vehicleService.getMakes().subscribe(makes =>
            this.makes = makes);
        this.vehicleService.getFeatures().subscribe(features =>
            this.features = features);
        this.vehicleService.getVehicles().subscribe(res =>
            this.vehicles = res);
    }

    onMakeChange() {
        var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
        this.carModels = selectedMake ? selectedMake.carModels : [];
        delete this.vehicle.modelId;
    }

    onFeatureToggle(featureId, $event) {
        if ($event.target.checked)
            this.vehicle.features.push(featureId);
        else {
            var index = this.vehicle.features.indexOf(featureId);
            this.vehicle.features.splice(index, 1);
        }
    }

    submit() {
        this.vehicleService.updateVehicle(this.vehicle, this.vehicleToChange)
            .subscribe(x => console.log(x));
    }

}
