import { Component, OnInit, Input, ViewChild, TemplateRef } from '@angular/core';
import { Vehicle } from '../../../services/vehicle.model';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { VehicleService } from '../../../services/vehicle.service';


@Component({
  selector: 'app-vehicle-item',
  templateUrl: './vehicle-item.component.html',
  styleUrls: ['./vehicle-item.component.css']
})
export class VehicleItemComponent implements OnInit {
    closeResult: string;
    isHot: boolean;
    @Input() vehicle: Vehicle;
    modalRef: BsModalRef;
    constructor(private modalService: BsModalService, private vehicleService: VehicleService) { }
    openModal(template: TemplateRef<any>) {
        this.vehicle.counter++;
        this.vehicleService.increaseCounter(this.vehicle.id);
        this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    }

    showHotIcon(): boolean {
        if (this.vehicle.counter > 8) {
            return true;
        }
        return false;
    }
    public deleteVehicle() {
        console.log('calling vehicleService')
        this.vehicleService.deleteVehicle(this.vehicle.id);
        this.modalRef.hide();
        window.location.reload();
    }

   
    ngOnInit() {
    }


}
