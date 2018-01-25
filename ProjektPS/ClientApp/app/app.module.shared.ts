import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { VehicleService } from './services/vehicle.service';
import { LocationService } from './services/location.service';
import { EditVehicleComponent } from './components/edit-vehicle/edit-vehicle.component';

import { VehicleItemComponent } from './components/home/vehicle-item/vehicle-item.component';
import { VehicleListComponent } from './components/home/vehicle-list/vehicle-list.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ChartsModule } from 'ng2-charts';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VehicleFormComponent,
        VehicleItemComponent,
        VehicleListComponent,
        EditVehicleComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ModalModule.forRoot(),
        ChartsModule,
        BrowserModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'vehicles/new', component: VehicleFormComponent },
            { path: 'vehicles/edit', component: EditVehicleComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        VehicleService,
        LocationService
    ]
})
export class AppModuleShared {
}
