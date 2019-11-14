import { Component} from '@angular/core';
import { DrivingTestService } from './shared/services/DrivingTestService';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
  providers: [DrivingTestService]
})
export class AppComponent{
}
