import { DrivingTest } from "../shared/entities/DrivingTest";
import { DrivingTestService } from "../shared/services/DrivingTestService";
import { Component } from "@angular/core";

@Component({
    selector: 'user-history',
    templateUrl: './user-history.component.html',
    providers: [DrivingTestService]
})
export class UserHistoryComponent {
    driwingTests: DrivingTest[];

    constructor(private drivingTestService: DrivingTestService) { }

    ngOnInit() {
        this.loadTests();
    }

    loadTests() {
        this.drivingTestService.getTests()
            .subscribe((data: DrivingTest[]) => this.driwingTests = data);
    }
}
