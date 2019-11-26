import { DrivingTest } from "../shared/entities/DrivingTest";
import { DrivingTestService } from "../shared/services/DrivingTestService";
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { RoadSituation } from "../shared/entities/RoadSituation";

@Component({
    selector: 'test-description',
    templateUrl: './test-description.component.html',
    providers: [DrivingTestService]
})
export class TestDescriptionComponent {

    id: number;
    drivingTest: DrivingTest;
    roadSituations: RoadSituation[];


    constructor(private drivingTestService: DrivingTestService, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
        this.loadTest();
    }

    loadTest() {
        if (this.id) {
            this.drivingTestService.getTest(this.id)
                .subscribe((data: DrivingTest) => this.drivingTest = data);
        }

    }
}
