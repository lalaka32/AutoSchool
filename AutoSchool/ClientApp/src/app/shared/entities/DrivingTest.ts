import { User } from './User';
import { TestRules } from './TestRules';
import { formatDate } from '@angular/common';

export class DrivingTest {
  constructor(
    public id?: number,
    public userId?: number,
    public user?: User, 
    public rulesSections?: TestRules[],
    public addedAt?: Date,
    public updatedAt?: Date,
    public success?: boolean
  ) { }
}
