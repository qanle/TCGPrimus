import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { DesignTime } from './designtimes';

@Injectable()
export class DesingTimesService {

    

    constructor(private http: HttpClient) { }

    getDesignTime() {
        return this.http.get<any>('assets/showcase/data/tcg-design-time.json')
        .toPromise()
        .then(res => <DesignTime[]>res.data)
        .then(data => { 
            return data; });
    }

}