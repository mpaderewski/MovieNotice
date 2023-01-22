export class Movie {
    constructor(
      public id: number = -1,
      public imdbId: string = '',
      public description: string = '',
      public title: string = '',
      public posterUrl: string = '',
      public releaseDate: string = '',
      public backdropPath: string = '',
      public popularity: number = -1
    ) { }
  }