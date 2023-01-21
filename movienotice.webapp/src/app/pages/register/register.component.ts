import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/Models/Movie';
import { RemoteMoviesService } from 'src/app/_services/remoteMovies/remoteMovies.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  
  public movies: Movie[] = [];

  constructor(private remoteMoviesService: RemoteMoviesService) {}

  ngOnInit(): void {
    this.remoteMoviesService.getMovies('Harry Potter').subscribe((response) => {
      this.movies = response;
      console.log('filmy');
      console.log(this.movies);
    });
  }

}
