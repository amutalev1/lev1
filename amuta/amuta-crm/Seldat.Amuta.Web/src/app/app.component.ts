import { Component } from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import { SharedService } from './shared/services/shared.service';
import { rootRenderNodes } from '@angular/core/src/view';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private translate: TranslateService,private sharedService:SharedService)
  {
    translate.addLangs(['English', 'Hebrew']);
    translate.setDefaultLang('Hebrew');
    translate.use('Hebrew');
    this.sharedService.changeDirection("rtl");
  }
  changeLang(lang: string) {
    document.dir = lang == "Hebrew" ? "rtl" : "ltr";
    lang="English"
    this.translate.use(lang);
    var direction=lang == "Hebrew" ? "rtl" : "ltr";
    this.sharedService.changeDirection(direction);
  }
  title = 'SeldatAmutaWeb';
}
