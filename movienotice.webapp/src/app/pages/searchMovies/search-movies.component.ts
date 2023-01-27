import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/Models/Movie';
import { RemoteMoviesService } from 'src/app/_services/remoteMovies/remoteMovies.service';


@Component({
  selector: 'app-search-movies',
  templateUrl: './search-movies.component.html',
  styleUrls: ['./search-movies.component.css']
})
export class SearchMoviesComponent implements OnInit{

  movies: Movie[] = [];
  constructor(private remoteMoviesService: RemoteMoviesService, private route: ActivatedRoute, private toasters: ToastrService) {
    
  }

  ngOnInit(): void {
    this.route.params
      .subscribe(params => {
        console.log(params['title']);     
        if(params['title'] != undefined) {
          this.remoteMoviesService.getMovies(params['title']).subscribe((response) => {
            this.movies = response;
            if(this.movies.length <= 0) {
              this.toasters.warning('Dla frazy: <b>' + params['title'].toString() + '</b> nic nie odnaleziono. Spróbuj wpisać innymi słowami.', 'Nie znaleziono żadnego filmu');
            }          
          });
        }
        else {
          console.log(this.route);
          this.remoteMoviesService.getPopularMovies().subscribe((response) => {
            this.movies = response;
            if(this.movies.length <= 0) {
              this.toasters.warning('Nie udało się załadować aktualnie popularnych filmów.', 'Nie znaleziono żadnego filmu');
            }    
          });
        }
      });   
  }

  hasMovies() {
    return this.movies.length > 0;
  }

  public handleMissingImage(event: Event) {
    (event.target as HTMLImageElement).style.display = 'none';
  }
}
