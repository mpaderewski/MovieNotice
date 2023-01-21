import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppSettings } from 'src/app/appSettings';
import { Movie } from 'src/app/Models/Movie';

const CONTROLLER = 'RemoteMovies/';

@Injectable({
  providedIn: 'root'
})

export class RemoteMoviesService {

  constructor(private http: HttpClient) { }
  
  getMovies(title: string) {
    return this.http.get<Movie[]>(AppSettings._API_URL + CONTROLLER + title);
  }
 
}



