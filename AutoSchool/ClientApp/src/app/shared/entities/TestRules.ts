import { RulesSection } from './RulesSection';
import { DrivingTest } from './DrivingTest';


export class TestRules {
    constructor(
        public id?: number,
        public rulesSectionId?: number,
        public rulesSections?: RulesSection,
        public drivingTestId?: number,
        public drivingTest?: DrivingTest
    ) { }
}
