import { RuleSection } from './RuleSection';
import { DrivingTest } from './DrivingTest';


export class TestRules {
    constructor(
        public id?: number,
        public ruleSectionId?: number,
        public ruleSection?: RuleSection,
        public drivingTestId?: number,
        public drivingTest?: DrivingTest
    ) { }
}
