// jQuery SerializeToJSON v1.2.0
// github.com/raphaelm22/jquery.serializeToJSON
!function(e){"use strict";e.fn.serializeToJSON=function(t){var a={settings:e.extend(!0,{},e.fn.serializeToJSON.defaults,t),getValue:function(t){var a=t.val();if(t.is(":radio")&&(a=t.filter(":checked").val()||null),t.is(":checkbox")&&(a=e(t).prop("checked")),this.settings.parseBooleans){var r=(a+"").toLowerCase();"true"!==r&&"false"!==r||(a="true"===r)}var n=this.settings.parseFloat.condition;return void 0!==n&&("string"==typeof n&&t.is(n)||"function"==typeof n&&n(t))&&(a=this.settings.parseFloat.getInputValue(t),a=Number(a),this.settings.parseFloat.nanToZero&&isNaN(a)&&(a=0)),a},createProperty:function(e,t,a,r){for(var n=e,i=0;i<a.length;i++){var s=a[i];if(i===a.length-1){var l=r.is("select")&&r.prop("multiple");l&&null!==t?(Array.isArray(n[s])||(n[s]=new Array),n[s].push(t)):n[s]=t}else{var o=/\[\w+\]/g.exec(s),u=null!=o&&o.length>0;if(u){s=s.substr(0,s.indexOf("[")),this.settings.associativeArrays?n.hasOwnProperty(s)||(n[s]={}):Array.isArray(n[s])||(n[s]=new Array),n=n[s];var c=o[0].replace(/[\[\]]/g,"");s=c}n.hasOwnProperty(s)||(n[s]={}),n=n[s]}}},includeUncheckValues:function(t,a){e(":radio",t).each(function(){var t=0===e("input[name='"+this.name+"']:radio:checked").length;t&&a.push({name:this.name,value:null})}),e("select[multiple]",t).each(function(){null===e(this).val()&&a.push({name:this.name,value:null})})},serializer:function(t){var a=this,r=e(t).serializeArray();this.includeUncheckValues(t,r);var n={};return e.each(r,function(r,i){var s=e(":input[name='"+i.name+"']",t),l=a.getValue(s),o=i.name.split(".");a.createProperty(n,l,o,s)}),n}};return a.serializer(this)},e.fn.serializeToJSON.defaults={associativeArrays:!0,parseBooleans:!0,parseFloat:{condition:void 0,nanToZero:!0,getInputValue:function(e){return e.val().split(",").join("")}}}}(jQuery);