import { DrivingTest } from './DrivingTest';


export class RoadSituation {
    constructor(
        public id?: number,
        public drivingTestId?: number,
        public drivingTest?: DrivingTest,
        public success?: boolean,
        public hasSigns?: boolean,
        public hasTrafficLight?: boolean,
        public hasVip?: boolean
    ) { }
}
