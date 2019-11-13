import { Component, OnInit } from '@angular/core';
import { DrivingTestService } from './shared/services/DrivingTestService';
import { DrivingTest } from './shared/entities/DrivingTest';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
  providers: [DrivingTestService]
})
export class AppComponent implements OnInit {

    driwingTests: DrivingTest[];

    constructor(private drivingTestService: DrivingTestService) { }

    ngOnInit() {
        this.loadTests();
    }

    loadTests() {
        this.drivingTestService.get()
            .subscribe((data: DrivingTest[]) => this.driwingTests = data);
    }
}
