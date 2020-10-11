import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Extractor } from './extractors';

@Injectable()
export class ExtractorsService {
   
    constructor(private http: HttpClient) { }

    getExtractor() {
        return this.http.get<any>('assets/showcase/data/tcg-extractor.json')
        .toPromise()
        .then(res => <Extractor[]>res.data)
        .then(data => { 
            return data; });
    }

}