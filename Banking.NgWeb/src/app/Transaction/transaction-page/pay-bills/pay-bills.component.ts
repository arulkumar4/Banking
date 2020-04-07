import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-pay-bills',
  templateUrl: './pay-bills.component.html',
  styleUrls: ['./pay-bills.component.css']
})
export class PayBillsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    $(document).ready(function(){
      $(".cardCls").hide();
      $(".clsPhone").hide();
      $(".clsLandline").hide();
      $(".clsDth").hide();
      $(".bulb").hide();
      $(".clsbulb").hide();
      $(".clsgas").hide();
      $(".clsmutual").hide();
      // card
      $(".atm").click(function(){
        $(".cardCls").show();
        $(".clsPhone").hide();
        $(".clsDth").hide();
        $(".clsLandline").hide();
        $(".clsbulb").hide();
        $(".clsgas").hide();
        $(".clsmutual").hide();

      });
      //phone
      $(".phone").click(function(){
        $(".clsPhone").show();
        $(".cardCls").hide();
        $(".clsDth").hide();
        $(".clsLandline").hide();
        $(".clsbulb").hide();
        $(".clsgas").hide();
        $(".clsmutual").hide();
     });
      //landline
      $(".landline").click(function(){
        $(".clsLandline").show();
        $(".clsPhone").hide();
        $(".clsDth").hide();
        $(".cardCls").hide();
        $(".clsbulb").hide();
        $(".clsgas").hide();
        $(".clsmutual").hide();
      });
      $(".dth").click(function(){
        $(".clsLandline").hide();
        $(".clsPhone").hide();
        $(".clsDth").show();
        $(".cardCls").hide();
        $(".clsbulb").hide();
        $(".clsgas").hide();
        $(".clsmutual").hide();
      });
      $(".waterTap").click(function(){
        $(".clsLandline").hide();
        $(".clsPhone").hide();
        $(".clsbulb").show();
        $(".cardCls").hide();
        $(".clsDth").hide();
        $(".clsgas").hide();
        $(".clsmutual").hide();
      });
      $(".cylinder").click(function(){
        $(".clsLandline").hide();
        $(".clsPhone").hide();
        $(".clsgas").show();
        $(".clsbulb").hide();
        $(".cardCls").hide();
        $(".clsDth").hide();
        $(".clsmutual").hide();
      });
      $(".money").click(function(){
        $(".clsLandline").hide();
        $(".clsPhone").hide();
        $(".clsmutual").show();
        $(".clsbulb").hide();
        $(".cardCls").hide();
        $(".clsDth").hide();
        $(".clsgas").hide();
      });
    });

  }

}
