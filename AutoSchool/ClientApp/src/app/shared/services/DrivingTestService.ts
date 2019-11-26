import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DrivingTest } from '../entities/DrivingTest';


@Injectable()
export class DrivingTestService {

    private url = "/api/testResult";

    constructor(private http: HttpClient) {
    }

    getTests() {
        return this.http.get(this.url + '/getAllByUser');
    }

    getTest(id: number) {
        return this.http.get(this.url + '/get/' + id);
    }

    //getTestRoadSituations() {
    //    return this.http.get(this.url + '/Get');
    //}
}
