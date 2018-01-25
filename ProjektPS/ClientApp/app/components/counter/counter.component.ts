import { Component, OnInit, AfterContentInit, DoCheck } from '@angular/core';
import { Vehicle } from '../../services/vehicle.model'
import { VehicleService } from '../../services/vehicle.service'
import { LocationService } from '../../services/location.service'
import { Location } from "../../services/location.model"

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html',
    styleUrls: ['./counter.component.css']
})
export class CounterComponent implements OnInit {
    HOW_MANY_TO_DISPLAY = 3;

    vehicles: Vehicle[];
    locations: Location[] = [];
    vehiclesToDisplay: string[] = [];
    vehicleOnPromo: string[] = [];
    isDataLoaded = true;
    cityMostViewed: string;
    cityNotViewed: string;
    //Bar Chart
    isBarChart = true;
    isDoughnatChart = false;
    public barChartData: any[] = [{
        data: [1], label: "Porshe"
    }];
    public barChartOptions: any = {
        scaleShowVerticalLines: false,
        responsive: true
    };
    public barChartLabels = new Array();

    public barChartType: string = 'bar';
    public barChartLegend: boolean = true;
    public arrayOfClicks = new Array();


    //Doughnat chart
    public doughnatChartData: number[] = [];
    public doughnutChartType: string = 'doughnut';
    public doughnutChartLabels: string[] = [];
    public doughnutChartOptions: any = {
        responsive: true
    };
    constructor(private vehicleService: VehicleService, private locationService: LocationService) { }

    ngOnInit() {
        this.vehicles = this.vehicleService.test();
        this.locations = this.locationService.getLocations();
        this.createArrayOfClicks();
        this.createListOfVehicleName();
        this.createBarChartData();
        this.createDoughnatChartData();
        this.createDoughnatChartLabel();
        this.promotionVehicleArray();
        this.cityMostViewed = this.locations[0].name;
        this.cityNotViewed = this.locations[this.locations.length - 1].name;
    }
    
 


    showBarChart() {
        this.isBarChart = true;
    }

    showCircleChart() {
        this.isBarChart = false;
    }
  
    public createListOfVehicleName() {
        for (var i = 0; i <= this.HOW_MANY_TO_DISPLAY; i++) {
            this.barChartLabels[i] = this.vehicles[i].name;
            if (i < 5) {
                this.vehiclesToDisplay[i] = this.vehicles[i].name;
            }
        }
    }

    public createArrayOfClicks() {
        for (var i = 0; i <= this.HOW_MANY_TO_DISPLAY; i++) {
            this.arrayOfClicks.push(this.vehicles[i].counter);
        }
    }

    public createBarChartData() {
        for (var i = 0; i <= this.HOW_MANY_TO_DISPLAY; i++) {
            this.barChartData[i] = {
                data: [this.vehicles[i].counter],
                label: this.vehicles[i].name
            };
         
        }
    }
    promotionVehicleArray() {
        for (var i = this.vehicles.length - 1; i > this.vehicles.length - 2; i--) {
            this.vehicleOnPromo.push(this.vehicles[i].name);
        }
    }
    createDoughnatChartData() {
        this.locations.forEach(loc => {
            this.doughnatChartData.push(loc.counter);
        }
        )
    }

    createDoughnatChartLabel() {
        this.locations.forEach(loc => {
            this.doughnutChartLabels.push(loc.name);
        })
    }
    // events
    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }

}
