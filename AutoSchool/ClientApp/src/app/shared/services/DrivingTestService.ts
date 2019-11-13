import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DrivingTest } from '../entities/DrivingTest';


@Injectable()
export class DrivingTestService {

    private url = "/api/TestResult";

    constructor(private http: HttpClient) {
    }

    get() {
        return this.http.get(this.url + '/GetAllByUser');
    }
}
