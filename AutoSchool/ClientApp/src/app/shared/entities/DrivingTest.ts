import { User } from './User';
import { TestRules } from './TestRules';
import { formatDate } from '@angular/common';
import { RuleSection } from './RuleSection';
import { RoadSituation } from './RoadSituation';

export class DrivingTest {
    constructor(
        public id?: number,
        public userId?: number,
        public ruleSectionName?: string,
        public roadSituations?: RoadSituation[],
        public addedAt?: Date,
        public updatedAt?: Date,
        public success?: boolean
    ) { }
}
