import { Component, Inject } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { Image } from '../../../interfaces/image.module'

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

    Images!: Image[] | null;
    selectedImage!: Image | null;

    displayDialog!: boolean;

    constructor(private activatedRoute: ActivatedRoute,
        private router: Router,
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) {

        this.displayDialog = false;

        this.http.get<Image[]>(baseUrl).subscribe(result => {
            this.Images = result;
            console.log(this.Images);
        }, error => console.error(error));
    }


    ngOnInit() {
    }

    selectImage(event: Event, image: Image){
        this.selectedImage = image;
        this.displayDialog = true;
    }

    onDialogHide() {
        this.selectedImage = null;
    }
}
