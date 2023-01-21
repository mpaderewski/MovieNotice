import { TestBed } from '@angular/core/testing';

import { RemoteMoviesService } from './remoteMovies.service';

describe('RemoteMoviesService', () => {
  let service: RemoteMoviesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RemoteMoviesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
