# 問題メモ

- 問題URL:
- ランク:
- 制限: 5.0 秒 / 512 MB

以下問題ページのソースのコピペ。
＝＝＝


<!DOCTYPE html>
<html lang='ja'>
<head>

<meta charset="utf-8">
<title>B108:観覧車の稼働状況の問題にチャレンジ！ | プログラミング学習サイト【paizaラーニング】</title>
<link rel="icon" type="image/x-icon" href="/favicon.ico">
<link rel="icon" type="image/svg+xml" href="/favicon.svg">
<meta name="description" content="B108:観覧車の稼働状況の問題ページです。GLHF｜環境構築不要、5秒で始められるプログラミング学習サイト【paizaラーニング】">
<meta property="og:title" content="B108:観覧車の稼働状況の問題にチャレンジ！">
<meta property="og:image" content="https://paiza.jp/images/ogp/og_paiza_works.png">
<meta property="og:type" content="company">
<meta property="og:url" content="https://paiza.jp/challenges/527/show">
<meta property="og:site_name" content="B108:観覧車の稼働状況の問題にチャレンジ！">
<meta property="og:description" content="B108:観覧車の稼働状況の問題ページです。GLHF｜環境構築不要、5秒で始められるプログラミング学習サイト【paizaラーニング】">
<meta property="og:locale" content="ja_JP">
<meta property="fb:app_id" content="896098410425951">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta name="copyright" content="Copyright Paiza, Inc. All rights reserved.">
<meta name="robots" content="index, follow">
<link href='/apple-touch-icon.png' rel='apple-touch-icon' sizes='192x192'>
<meta content='paiza' name='application-name'>
<meta content='/small.jpg' name='msapplication-square70x70logo'>
<meta content='/medium.jpg' name='msapplication-square150x150logo'>
<meta content='/wide.jpg' name='msapplication-wide310x150logo'>
<meta content='/large.jpg' name='msapplication-square310x310logo'>
<meta content='width=1024' name='viewport'>
<link rel="stylesheet" href="https://paiza.jp/assets/common/reset-9f56b21aeebbed9efcdd6fd346f954c6f64ba5792ecec8f465aa08db199a6a7a.css" media="screen,print" />
<link rel="stylesheet" href="https://paiza.jp/assets/init_bootstrap-335151b0a77f3849dd04e8a9699d4fe5724000a863b18874858cf76b5285f5f7.css" media="screen,print" />
<link rel="stylesheet" href="https://paiza.jp/assets/common/application-c6da67b46ce620bd6b9f55861026e7ac704bed186527a99e84d46e752242248e.css" media="all" />
<link rel="stylesheet" href="https://paiza.jp/assets/common/colorbox-6d40c70f0b4f96d8e654bc874ef16e7735a244a38a1eab3b25764e0afa7f7c79.css" media="all" />
<link rel="stylesheet" href="https://paiza.jp/assets/common/sweet-alert-fd2b8d44a6319116076cae8939b4c5f9effe17436629256da8564f8e09f3a9e6.css" media="all" />
<link rel="stylesheet" href="https://paiza.jp/assets/application-9e5f57fd401428872aaf6b8362972dbbde53bff3added6b3f3bba091afdfeab3.css" media="all" />
<link rel="stylesheet" href="https://paiza.jp/assets/deprecated_common-ee83625519b9f652c99ddfb4614f33ef16d080f5b8d09f00ead3bfef5fa75bdb.css" media="screen,print" />
<link rel="stylesheet" href="https://paiza.jp/assets/common/print-79636e660e60e116e87b936a6adc4fcb3f3110d99a4ac06ed40ebeabf7320280.css" media="print" />
<script src="https://paiza.jp/assets/application-3539ed36e27d03f88b560aa3df1772ff4284285e332bcd6aa5e7d67f81ec7840.js"></script>
<script src="https://paiza.jp/assets/common/rollover-e5b650c5608a186aed955ccfcf537e5373745e356de733ab3c8459d4e19fc297.js" defer="defer"></script>
<script src="https://paiza.jp/assets/common/social_button-3609608d2fa7bd3cde91854101df1ce31b5b834b254b924cec1fcea28b2aa5f9.js" async="async"></script>
<script src="https://paiza.jp/assets/common/easing_scroll-b07c5164dbd1ab0d89ac9f3cf99a3f3d819817df6f77f315b63e13b4a1f44ad7.js" defer="defer"></script>
<link rel="stylesheet" href="https://paiza.jp/assets/problem-eca7bd8057e4e3ddf2b4aad5641151079888ba5f326c41d540999f6a105f8844.css" media="screen,print" />
<link rel="stylesheet" href="https://paiza.jp/assets/common/editor-f6a7169c2cd59d32f92702bb3a9f631737b4a8d1a04562902ef558b7191d13de.css" />
<link rel="stylesheet" href="https://paiza.jp/assets/skillcheck/sample-122f945221f40ef12a168d6253b6ad56914cbb2aaf0d808cebf566d9cf0c643e.css" />
<script src="https://cdn-paiza.paiza.jp/packs/vendor/deprecated/ace.ad29aaa114f561ef.js" defer="defer"></script>
<script src="https://paiza.jp/assets/challenges/editor-bcfc24a5bc89e34d147a09e3582fa349d02ac5cae3de105af24499248b84b257.js" defer="defer"></script>
<script src="https://paiza.jp/plugin/countdown/vendor/jquery.plugin.js" defer="defer"></script>
<script src="https://paiza.jp/plugin/countdown/vendor/jquery.countdown.js" defer="defer"></script>
<script src="https://paiza.jp/plugin/countdown/vendor/jquery.countdown-ja.js" defer="defer"></script>
<script src="https://cdn-paiza.paiza.jp/packs/partials/commons/challenge_compile_and_test.2e7a040705eb71c7.js" defer="defer"></script>
<script src="https://cdn-paiza.paiza.jp/packs/partials/commons/challenge_code_submit.3f70cefbd215ae02.js" defer="defer"></script>
<script src="https://cdn-paiza.paiza.jp/packs/pages/challenges/show.b4a0fd3577c15462.js" defer="defer"></script>
<link rel="stylesheet" href="https://cdn-paiza.paiza.jp/packs/partials/commons/breadcrumbs_on_rails.185c4ead64565ed9.css" />
<script src="https://paiza.jp/assets/challenges/problem_content-4d0de9c1d45735cfd3a1a80d5c72151e0bf2a99fbec6279a5b98e52ce8031153.js"></script>

<link rel="stylesheet" href="https://cdn-paiza.paiza.jp/packs/fonts.6c4a7066673569c2.css" />
<link rel="stylesheet" href="https://cdn-paiza.paiza.jp/packs/backward_compatible_application.da99c1476338ca58.css" />
<link rel="stylesheet" href="https://cdn-paiza.paiza.jp/packs/partials/commons/flash_alert.f86b83a2dd99917e.css" />
<script src="https://cdn-paiza.paiza.jp/packs/backward_compatible_application.ef46db3751d8e999.js" defer="defer"></script>
<style>
  html {
    font-size: 16px;
  }
  body {
    font-size: 87.5%;
  }
</style>
<meta name="csrf-param" content="authenticity_token" />
<meta name="csrf-token" content="Cmh--x5pn5gMurfwtGgi2DXd23yaYFK_FSrRhGm2wPAHC9DraDv9APsHKEQgvWHUkp5bwlWu4KaSDDsPguq6Lw" />
<script>
  dataLayer = [];
  if (location.pathname.startsWith('/business')) {
    analytics_properties = {
      'business_user_id': ''
    };
  } else {
    analytics_properties = {
      'uuid': '6fe32406-f3b5-4c11-9779-76aea9d9ffeb',
      'user_status': '1',
      'status': '2000',
      'ga_status': '2000',
      'paiza_rank': '1802',
      'registered_service': 'career',
      'max_skillpr_years_of_experience': '2402',
      'expected_date_of_graduation': '2025-03-31',
      'school_type_id': '10620',
      'intent_job_change_id': '3201',
      'intent_to_be_engineer_id': '12100'
    };
  }
  
  dataLayer.push(Object.assign({}, analytics_properties));
</script>
<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-TQKX7WN');</script>
<!-- End Google Tag Manager -->
<script>
(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
})(window,document,'script','https://www.google-analytics.com/analytics.js','ga');
ga('create', 'UA-42027263-1', 'auto');
ga('require', 'GTM-544Q3L4');
ga('set', 'userId', '6fe32406-f3b5-4c11-9779-76aea9d9ffeb');
ga('set', 'dimension1', '1');
ga('set', 'dimension2', '2000');
ga('set', 'dimension3', '1802');
ga('set', 'dimension4', 'career');
ga('send', 'pageview');
</script>
<script>
  custom_dimensions = Object.assign({}, analytics_properties);
  custom_dimensions['user_properties'] = Object.assign({}, custom_dimensions);
  custom_dimensions['user_id'] = custom_dimensions['uuid'];
</script>
<script async='' src='https://www.googletagmanager.com/gtag/js?id=G-X4K98BR9EP'></script>
<script>
window.dataLayer = window.dataLayer || [];
function gtag(){dataLayer.push(arguments);}
gtag('js', new Date());
gtag('config', 'G-X4K98BR9EP', custom_dimensions);
</script>
<link rel="preconnect" href="https://dev.visualwebsiteoptimizer.com" />
<script type='text/javascript' id='vwoCode'>
window._vwo_code || (function() {
var account_id=804902,
version=2.0,
settings_tolerance=2000,
hide_element='body',
hide_element_style = 'opacity:0 !important;filter:alpha(opacity=0) !important;background:none !important',
<!-- * DO NOT EDIT BELOW THIS LINE */ -->
f=false,w=window,d=document,v=d.querySelector('#vwoCode'),cK='_vwo_'+account_id+'_settings',cc={};try{var c=JSON.parse(localStorage.getItem('_vwo_'+account_id+'_config'));cc=c&&typeof c==='object'?c:{}}catch(e){}var stT=cc.stT==='session'?w.sessionStorage:w.localStorage;code={use_existing_jquery:function(){return typeof use_existing_jquery!=='undefined'?use_existing_jquery:undefined},library_tolerance:function(){return typeof library_tolerance!=='undefined'?library_tolerance:undefined},settings_tolerance:function(){return cc.sT||settings_tolerance},hide_element_style:function(){return'{'+(cc.hES||hide_element_style)+'}'},hide_element:function(){return typeof cc.hE==='string'?cc.hE:hide_element},getVersion:function(){return version},finish:function(){if(!f){f=true;var e=d.getElementById('_vis_opt_path_hides');if(e)e.parentNode.removeChild(e)}},finished:function(){return f},load:function(e){var t=this.getSettings(),n=d.createElement('script'),i=this;if(t){n.textContent=t;d.getElementsByTagName('head')[0].appendChild(n);if(!w.VWO||VWO.caE){stT.removeItem(cK);i.load(e)}}else{n.fetchPriority='high';n.src=e;n.type='text/javascript';n.onerror=function(){_vwo_code.finish()};d.getElementsByTagName('head')[0].appendChild(n)}},getSettings:function(){try{var e=stT.getItem(cK);if(!e){return}e=JSON.parse(e);if(Date.now()>e.e){stT.removeItem(cK);return}return e.s}catch(e){return}},init:function(){if(d.URL.indexOf('__vwo_disable__')>-1)return;var e=this.settings_tolerance();w._vwo_settings_timer=setTimeout(function(){_vwo_code.finish();stT.removeItem(cK)},e);var t=d.currentScript,n=d.createElement('style'),i=this.hide_element(),r=t&&!t.async&&i?i+this.hide_element_style():'',c=d.getElementsByTagName('head')[0];n.setAttribute('id','_vis_opt_path_hides');v&&n.setAttribute('nonce',v.nonce);n.setAttribute('type','text/css');if(n.styleSheet)n.styleSheet.cssText=r;else n.appendChild(d.createTextNode(r));c.appendChild(n);this.load('https://dev.visualwebsiteoptimizer.com/j.php?a='+account_id+'&u='+encodeURIComponent(d.URL)+'&vn='+version)}};w._vwo_code=code;code.init();})();
</script>
<!-- End VWO Async SmartCode -->
<!-- Optimize Next -->
<script>(function(p,r,o,j,e,c,t,g){
p['_'+t]={};g=r.createElement('script');g.src='https://www.googletagmanager.com/gtm.js?id=GTM-'+t;r[o].prepend(g);
g=r.createElement('style');g.innerText='.'+e+t+'{visibility:hidden!important}';r[o].prepend(g);
r[o][j].add(e+t);setTimeout(function(){if(r[o][j].contains(e+t)){r[o][j].remove(e+t);p['_'+t]=0}},c)
})(window,document,'documentElement','classList','loading',2000,'WTZZHVXG')</script>
<!-- End Optimize Next -->
<script>
  (function() {
    this.gaq_push = function(args) {
      var hit_type, mkargs;
      if (args == null) {
        args = [];
      }
      mkargs = {};
      hit_type = '';
      args.forEach(function(n, i) {
        if (i === 0) {
          if (n === '_trackEvent') {
            hit_type = 'event';
          } else if (n === '_trackPageview') {
            hit_type = 'pageview';
          }
          return mkargs.hitType = hit_type;
        } else if (i === 1) {
          if (hit_type === 'event') {
            return mkargs.eventCategory = n.toString();
          } else if (hit_type === 'pageview') {
            return mkargs.page = n.toString();
          }
        } else if (i === 2) {
          return mkargs.eventAction = n.toString();
        } else if (i === 3) {
          return mkargs.eventLabel = n.toString();
        } else if (i === 4) {
          return mkargs.eventValue = parseInt(n);
        }
      });
      if (typeof ga !== "undefined" && ga !== null) {
        return ga('send', mkargs);
      } else {
        return console.log(mkargs);
      }
    };
  
  }).call(this);
</script>

<script>
(function(h,o,t,j,a,r){
h.hj=h.hj||function(){(h.hj.q=h.hj.q||[]).push(arguments)};
h._hjSettings={hjid:841012,hjsv:6};
a=o.getElementsByTagName('head')[0];
r=o.createElement('script');r.async=1;
r.src=t+h._hjSettings.hjid+j+h._hjSettings.hjsv;
a.appendChild(r);
})(window,document,'https://static.hotjar.com/c/hotjar-','.js?sv=');
</script>

</head>
<body class=''>
<!-- Google Tag Manager (noscript) -->
<noscript>
<iframe height='0' src='https://www.googletagmanager.com/ns.html?id=GTM-TQKX7WN' style='display:none;visibility:hidden' width='0'></iframe>
</noscript>
<!-- End Google Tag Manager (noscript) -->
<div id='fb-root'></div>
<script src="https://cdn-paiza.paiza.jp/packs/partials/headers/global_header.809849df5c62ad0a.js" defer="defer"></script>
<link rel="stylesheet" href="https://cdn-paiza.paiza.jp/packs/partials/headers/global_header.16c5c12ddef8eebc.css" />
<div data-display-menu='true' data-enable-learning-path='false' data-is-agent-scouts-badge-visible='false' data-is-bookmarks-badge-visible='true' data-is-display-scout-config='false' data-is-entries-badge-visible='false' data-is-messages-badge-visible='true' data-is-mypage-badge-visible='false' data-is-student='false' data-is-study-group-user='false' data-is-target-of-plan-after-graduation='false' data-logged-in='true' data-new-graduates-target-year='' id='js-react-global-header'></div>


<noscript>
<p style='text-align:center;'>javascriptを有効にして下さい。</p>
</noscript>
<div class='disnon' data-status='2000' id='user_info'></div>
<div class='text-center pc-only' id='pagebody'>


<input type="hidden" name="problem_id" id="problem_id" value="527" autocomplete="off" />
<input type="hidden" name="problem_rank_id" id="problem_rank_id" value="1802" autocomplete="off" />
<textarea name="submit_code" id="submit_code" style="display:none;">
</textarea>
<input type="hidden" name="submit_programming_language_id" id="submit_programming_language_id" autocomplete="off" />
<style>
  .d-problem__page-title {
    padding: 5px 0 16px 66px;
    background: url(/images/paiza_kun.gif) left top no-repeat;
    position: relative;
    margin: 0 0 20px;
    color: #000;
    font-size: 33px;
    font-weight: bold;
    line-height: 1.4; }
    .d-problem__page-title:after {
      content: "";
      display: block;
      position: absolute;
      left: 0;
      bottom: 0;
      width: 100%;
      height: 6px;
      background: linear-gradient(to bottom, #175a6b, #29a1bf);
      border-radius: 3px 3px; }
  
  .d-problem__alert {
    font-weight: bold;
    color: #df2020;
    background-color: #f2dede;
    border-color: #ebccd1;
    padding: 15px;
    margin-bottom: 20px;
    border: 1px solid transparent;
    border-radius: 4px; }
  
  .d-problem .problem-format-explanation {
    display: flex;
    width: 960px;
    margin: 0 auto;
    padding: 15px 20px;
    border-radius: 6px;
    border: solid 1px #d2d5da; }
    .d-problem .problem-format-explanation__title {
      display: flex;
      font-weight: bold;
      width: 150px;
      align-items: center; }
    .d-problem .problem-format-explanation__content {
      display: flex;
      flex-direction: column;
      width: 805px; }
    .d-problem .problem-format-explanation__guide {
      color: #2692ac; }
</style>
<div class='d-problem'>
<div class='boxSkillcheck mb5'>
</div>
<style>
  .d-problem-content__timer {
    padding: 0 0 0 38px;
    background: url(/images/member/icon_06.gif) no-repeat 0 2px;
    position: absolute;
    top: 24px;
    right: 30px; }
  
  .d-problem-content__timer-dt {
    font-size: 86%;
    line-height: 140%; }
  
  .d-problem-content__timer-dd {
    font-size: 114%;
    font-weight: bold;
    line-height: 140%; }
  
  .d-problem-content__background-side {
    width: 964px;
    background: url(/images/member/bg_04b.gif) repeat-y left top;
    position: relative;
    left: -2px; }
  
  .d-problem-content__background-top {
    width: 100%;
    background: url(/images/member/bg_04a.gif) no-repeat left top; }
  
  .d-problem-content__background-bottom {
    width: 100%;
    padding: 18px 0 15px 0;
    background: url(/images/member/bg_04c.gif) no-repeat left bottom;
    position: relative; }
  
  .d-problem-content__problem-title {
    background-image: url(/images/member/bg_code2_01a.gif);
    font-size: 128%;
    font-weight: bold;
    line-height: 50px;
    color: #fff;
    margin: 0 0 20px 0;
    padding: 0 0 0 5px;
    background-repeat: no-repeat;
    background-position: left top;
    position: relative;
    left: -3px; }
    .d-problem-content__problem-title:before {
      display: table;
      content: " "; }
    .d-problem-content__problem-title:after {
      display: table;
      content: " ";
      clear: both; }
  
  .d-problem-content__problem-title-background {
    background-image: url(/images/member/bg_code2_01b.gif);
    height: 53px;
    padding: 0 110px 0 15px;
    background-repeat: no-repeat;
    background-position: right top;
    display: block;
    float: left; }
</style>
<div class='boxSkillcheck mb5'>
<h1 class='d-problem__page-title'>B108:観覧車の稼働状況</h1>
<div class='d-problem-content'>
<div class='section3'>
<div class='d-problem-content__background-top'>
<div class='d-problem-content__background-bottom'>
<h2 class='d-problem-content__problem-title code4'>
<span class='d-problem-content__problem-title-background'>B108:観覧車の稼働状況</span>
</h2>
<dl class='d-problem-content__timer'>
<dt class='d-problem-content__timer-dd'>
<span class='js-count-up-elapsed-time'>
<!-- / jsで経過時間は動的に変更される -->
経過時間取得中...
</span>
</dt>
<dd class='d-problem-content__timer-dt'>
6時間経過で時間切れ
</dd>
</dl>
<div class='js-problem_content_html' data-applicant-challenge-result-id='10050410' data-copy-histories-url='https://paiza.jp/api/applicant_challenge_result_copy_histories'>
<div class="inr1">
  <p class="mb15">
<p>あなたは PAIZA 遊園地で働くエンジニアです。あなたは今回、観覧車の稼働状況を確認するプログラムを実装することになりました。<br/>
<br/>
PAIZA 遊園地の観覧車には N 個のゴンドラがあります。N 個のゴンドラには 1 から N までの番号が時計回りの順で付与されており、番号が i のゴンドラには A_i 人まで乗ることができます (1 ≦ i ≦ N)。観覧車は、反時計回りに回転します。<br/>
<br/>
開園後すぐに、M 組のグループが観覧車の待機列に並びました。先頭から i 番目のグループは B_i 人の人がいます (1 ≦ i ≦ M)。それぞれのグループの人は、次のように観覧車に乗ります。<br/>
<br/>
・先頭のグループから順番に乗り場にあるゴンドラに乗車していく。<br/>
・今乗り場にあるゴンドラにグループ全員が乗れる場合、全員がそのゴンドラに乗る。<br/>
・今乗り場にあるゴンドラにグループ全員が乗れない場合、乗り場にあるゴンドラに乗車できる分の人だけが乗り、残りの人は次にくるゴンドラを待つ。<br/>
・乗り場にゴンドラ i があり、ゴンドラ i への乗車が完了した場合、次に乗り場にはゴンドラ i + 1 が到着する。(1 ≦ i ≦ N - 1)。ただし、ゴンドラ N の次にはゴンドラ 1 が到着するものとする。<br/>
・異なるグループの人が同じゴンドラに乗ることはないものとする。<br/>
・それぞれのゴンドラは 1 周すると乗り場に戻る。乗り場に戻った時点で、乗車していた客は全員降りる。<br/>
<br/>
開園時点で、乗り場にはゴンドラ 1 が待機しているものとします。<br/>
<br/>
M 組目のグループの人が全員ゴンドラから降りたタイミングまでに、各ゴンドラが乗せた客の人数を求めるプログラムを作成してください。ただし、開園後すぐに待機列に並んだ M 組のグループ以外の利用者はいないものとします。<br/>
<br/>
例えば入力例 1 の場合、次のようになります。<br/>
入力例 1 では 3 つのゴンドラがあり、それぞれのゴンドラが 5 人乗りのゴンドラになっています。また、現在観覧車には 3 組のグループが並んでいます。1 番目のグループには 6 人、2 番目のグループには 5 人、3 番目のグループには 3 人の人がいます。<br/>

<p><img alt="図1" src="http://paiza.s3.amazonaws.com/problem/img/527/img1.png" /></p>

まず、グループ 1 の人が観覧車に乗り込んでいきます。1 番目のゴンドラに 5 人、2 番目のゴンドラに 1 人が乗ります。<br/>

<p><img alt="図2" src="http://paiza.s3.amazonaws.com/problem/img/527/img2.png" /></p>

次に、グループ 2 の人が観覧車に乗り込んでいきます。2 番目のゴンドラに空きがありますが、グループ 1 の人が乗っているので乗り込めません。3 番目のゴンドラに 5 人全員が乗ります。<br/>

<p><img alt="図3" src="http://paiza.s3.amazonaws.com/problem/img/527/img3.png" /></p>

次に、グループ 3 の人が観覧車に乗り込んでいきます。グループ 1 の人が乗っていた 1 番目のゴンドラが乗り場に戻ってきたときに、3 人全員が乗り込みます。<br/>

<p><img alt="図4" src="http://paiza.s3.amazonaws.com/problem/img/527/img4.png" /></p>

よって、<br/>
・ゴンドラ 1 は計 8 人<br/>
・ゴンドラ 2 は計 1 人<br/>
・ゴンドラ 3 は計 5 人<br/>
<br/>
を乗せたことになります。
</p>
</div>
<div class="inr2">
  <div class="box2">
    <dl class="txt1">
    <dt class="icon1">評価ポイント</dt>
    <dd>
    10回のテストケースで、正答率、実行速度、メモリ消費量をはかり得点が決まります。<br />
    より早い解答時間で提出したほうが得点が高くなります。
    <ol>
    <li>複数のテストケースで正しい出力がされるか評価（+50点）</li>
    <li>解答までの速さ評価（+50点）</li>
    </ol>
    </dd>
    </dl>
  </div>
  <div class="box3">
    <dl class="txt1">
    <dt class="icon2">入力される値</dt>
    <dd>
      <p>入力は以下のフォーマットで与えられます。</p>
<pre><code>N M
A_1
A_2
...
A_N
B_1
B_2
...
B_M</code></pre>
<ul>
<li>・1 行目にそれぞれゴンドラの数とグループの数を表す整数 N, M がこの順で半角スペース区切りで与えられます。</li>
<li>・続く N 行のうちの i 行目 (1 ≦ i ≦ N) には、i 番目のゴンドラに乗車できる人数の制限を表す整数 A_i が与えられます。</li>
<li>・続く M 行のうちの i 行目 (1 ≦ i ≦ M) には、i 番目のグループの人数を表す整数 B_i が与えられます。</li>
<li>・入力は合計で N + M + 1 行となり、入力値最終行の末尾に改行が 1 つ入ります。</li></ul>
<br />
             それぞれの値は文字列で標準入力から渡されます。<a class="targetBlank" href="/guide/samplecode.html" target="_blank">標準入力からの値取得方法はこちらをご確認ください</a><br />
    </dd>
    </dl>
  </div>

  <div class="box3">
    <dl class="txt1">
      <dt class="icon3">期待する出力</dt>
    <dd>
<p>各ゴンドラに乗った人の合計数を以下の形式で出力してください。<br/>

<pre><code>C_1
C_2
...
C_N</code></pre>

・期待する出力は N 行からなります。<br/>
・i 行目 (1 ≦ i ≦ N) にはそれぞれ i 番目のゴンドラに乗った人の合計数を表す整数 C_i を出力してください。<br/>
・N 行目の出力の最後に改行を入れ、余計な文字、空行を含んではいけません。<br/>
</p>
    </dd>
    </dl>
  </div>
  <div class="box3">
    <dl class="txt1">
    <dt class="icon4">条件</dt>
    <dd>
        <p>すべてのテストケースにおいて、以下の条件をみたします。</p>
<ul>
<li>・1 ≦ N, M ≦ 30</li>
<li>・1 ≦ A_i ≦ 100 (1 ≦ i ≦ N)</li>  
<li>・1 ≦ B_i ≦ 100 (1 ≦ i ≦ M)</li>
</ul>
</li>
</dd>
    </dl>
  </div>

</div>

</div>
<div class='sample-container'>
<div class="sample-content"><div class="sample-content__title">入力例1</div><pre class="sample-content__input"><code>3 3
5
5
5
6
5
3
</code></pre></div><div class="sample-content"><div class="sample-content__title">出力例1</div><pre class="sample-content__input"><code>8
1
5
</code></pre></div>
<div class="sample-content"><div class="sample-content__title">入力例2</div><pre class="sample-content__input"><code>4 6
4
2
4
2
9
3
5
7
1
3
</code></pre></div><div class="sample-content"><div class="sample-content__title">出力例2</div><pre class="sample-content__input"><code>10
5
7
6
</code></pre></div>
<div class="sample-content"><div class="sample-content__title">入力例3</div><pre class="sample-content__input"><code>2 1
10
10
3
</code></pre></div><div class="sample-content"><div class="sample-content__title">出力例3</div><pre class="sample-content__input"><code>3
0
</code></pre></div>



</div>
</div>
</div>
</div>
</div>
</div>

<div class='boxMember'>
<div class='boxEditor'>
<div class='d-editor-guide-messages'>
<div class='d-editor-guide-messages__row'>
<span aria-hidden='true' class='d-editor-guide-messages__icon d-editor-guide-messages__icon--attention'></span>
<div class='d-editor-guide-messages__description'>
paizaでは提出されたコードが、AIや他者からヒント・解答を得て作成されたものでないことを常時監視しております。
</div>
</div>
<div class='d-editor-guide-messages__row'>
<span aria-hidden='true' class='d-editor-guide-messages__icon d-editor-guide-messages__icon--question'></span>
<div class='d-editor-guide-messages__description'>
<p style='color: #FF6600;'>複数のテストケースでテストしますので、動作確認用の入力例だけでなく入力値を変えてのデバッグをおすすめします。</p>
<p>エディタが正常に動作しない場合はブラウザ拡張機能をすべて無効化してください。</p>
<p>標準入力（「入力される値」の取得・処理）が分からない場合は、サンプルコードや動画解説をご参照ください。</p>
<div style='margin-top: 10px;'>
<div class='d-editor-guide-messages__guide'>
<span aria-hidden='true' class='p-challenges-icon p-challenges-icon--arrow-circle-right'></span>
<a target="_blank" rel="noopener" class="targetBlank" href="https://paizasupport.zendesk.com/hc/ja/articles/360038391912?parts=suppl-for-codearea&amp;paiza_rank=1802#section_lets_practice">標準入力に関する動画解説など（FAQ「標準入力・出力とはなんですか？」）</a>
</div>
<div class='d-editor-guide-messages__guide'>
<span aria-hidden='true' class='p-challenges-icon p-challenges-icon--arrow-circle-right'></span>
<a target="_blank" rel="noopener" class="targetBlank" href="/guide/samplecode">コードの評価方法やサンプルコード（「値取得・出力サンプルコード」）</a>
</div>
</div>
</div>
</div>
<div class='d-editor-guide-messages__row'>
<span aria-hidden='true' class='d-editor-guide-messages__icon d-editor-guide-messages__icon--gear'></span>
<div class='d-editor-guide-messages__description'>
実行環境については、
<a target="_blank" href="/guide/language">各言語のバージョン、環境情報</a>
をご参照ください。
</div>
</div>
</div>

<div class='editor_container'>
<input type="hidden" name="recovery_key" id="recovery_key" value="527" autocomplete="off" />
<div class='answer_wrap'>
<div class='title_wrap mb10'>
<h3 class='h3_title'>
解答コード入力欄
</h3>
<div class='answer_wrap_option'>
<select class="box form-control" name="language[id]" id="language_id"><option value="">使用する言語</option>
<option value="2300">Java</option>
<option value="2301">PHP</option>
<option value="2302">Ruby</option>
<option value="2303">Python2</option>
<option value="2321">Python3</option>
<option value="2304">Perl</option>
<option value="2305">C</option>
<option value="2306">C++</option>
<option value="2307">C#</option>
<option value="2308">JavaScript</option>
<option value="2309">Objective-C</option>
<option value="2310">Scala</option>
<option value="2311">Go</option>
<option value="2324">Swift</option>
<option value="2325">Kotlin</option></select>
</div>
</div>
<form class="simple_form edit_applicant_challenge_result" id="code_hand_in" novalidate="novalidate" action="/challenges/527/submit" accept-charset="UTF-8" method="post"><input type="hidden" name="_method" value="patch" autocomplete="off" /><input type="hidden" name="authenticity_token" value="-IIey902GjEWqJWumTYE9jWxOr-7eiXJz3pq_Uz790WHL6sexm_d4coNED3XX-CFWX1sCofHSZK2mZHXr8CJiQ" autocomplete="off" /><input id="programming_language_id" autocomplete="off" type="hidden" name="applicant_challenge_result[programming_language_id]" />
<input id="code" autocomplete="off" type="hidden" name="applicant_challenge_result[code]" />
</form><div class='row mb10'>
<div class='time_wrap strong pull-right'>
<span class='js-count-up-elapsed-time'>
<!-- / jsで経過時間は動的に変更される -->
経過時間取得中...
</span>
</div>
</div>
<div class='editor_wrap'>
<div class='editor_area'>
<div class='editor_ctr_btn_wrap'>
<div class='editor_ctr_btn m-t-10'>
<button class='btn btn-default btn-xs m-r-5' data-placement='bottom' data-toggle='tooltip' id='code_zoom' title='拡大する'>
<span aria-hidden='true' class='p-challenges-icon p-challenges-icon--search-plus'></span>
</button>
</div>
<div class='editor_ctr_btn'>
<button class='btn btn-default btn-xs m-r-5' data-placement='bottom' data-toggle='tooltip' id='code_zoom_out' title='縮小する'>
<span aria-hidden='true' class='p-challenges-icon p-challenges-icon--search-minus'></span>
</button>
</div>
<div class='editor_ctr_btn m-t-10'>
<button class='theme_color_box dark' data-placement='bottom' data-theme='dark' data-toggle='tooltip' title='エディターテーマを黒にする'></button>
</div>
<div class='editor_ctr_btn'>
<button class='theme_color_box white' data-placement='bottom' data-theme='white' data-toggle='tooltip' title='エディターテーマを白にする'></button>
</div>
<div class='editor_ctr_btn'>
<button class='theme_color_box orange' data-placement='bottom' data-theme='orange' data-toggle='tooltip' title='エディターテーマを黄色にする'></button>
</div>
</div>
<div id='editor-div' style='height: 250px; width: 100%'></div>
</div>
<div class='compile-test-area'>
<div class='compile-test-area__input-select'>
<label for='sample_input_no'>動作確認で使うテストケースを選択</label>
<select name="sample_input_no" id="sample_input_no" class="select box"><option value="0">入力例1</option>
<option value="1">入力例2</option>
<option value="2">入力例3</option></select>
</div>
<div class='compile-test-area__submit-button'>
<button name="button" type="submit" id="do_compile" onclick="compile_ang_test(&#39;/challenges/527/compile_and_test&#39;)" class="btn btn-primary m-r-5"><span aria-hidden='true' class='p-challenges-icon p-challenges-icon--gear'></span>
提出前動作確認
</button></div>
</div>
<div class='paiza_io_area'>
<a target="_blank" href="https://paiza.io/ja/projects/new">→入力値を自由に試す（paiza.IO）
<span aria-hidden='true' class='p-challenges-icon p-challenges-icon--external-link'></span>
</a></div>
</div>
</div>
<div class='loadingBox' style='display:none'>
<img alt="判定中…" class="center-block" ssl_detected="true" width="200" height="140" src="https://paiza.jp/member/images/txt_02.gif" />
</div>
<div class='output_wrap'></div>
<p class='text-center'>
<a id="handin" onclick="remove_stored_history(); hand_in_code(false);" class="btn btn-warning btn-lg m-r-5" href="javascript:void(0)">コードを提出する
</a><p class='text-center'>
一度提出すると修正できません
</p>
</p>
</div>

</div>
</div>
</div>

</div>
<script src="https://cdn-paiza.paiza.jp/packs/partials/footers/global_footer.17b8eb89cd34d5a6.js" defer="defer"></script>
<link rel="stylesheet" href="https://cdn-paiza.paiza.jp/packs/partials/footers/global_footer.fc8919272cf72136.css" />
<div class='s-breadcrumb'>
<div class='s-breadcrumb__inner'>
<ol class='s-breadcrumb__list' itemscope itemtype='http://schema.org/BreadcrumbList'><li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop="item" href="/"><span itemprop='name'>paizaトップ</span></a><meta content='1' itemprop='position'></li><li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop="item" href="/challenges"><span itemprop='name'>プログラミングスキルチェック</span></a><meta content='2' itemprop='position'></li><li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><span itemprop='name'>B108:観覧車の稼働状況</span><meta content='3' itemprop='position'></li></ol>
</div>
</div>

<div data-is-copyright-only='false' data-is-no-menu='false' data-is-sns-share-button-visible='true' data-logged-in='true' id='js-react-global-footer'></div>

<div id='pagetop'>
<a href="#"><img alt="ページの先頭へ戻る" class="rollover-image__on " data-rollover-path="https://paiza.jp/images/pagetop_o.png" onMouseover="this.src='https://paiza.jp/images/pagetop_o.png'" onMouseOut="this.src='https://paiza.jp/images/pagetop.png'" ssl_detected="true" width="60" height="60" src="https://paiza.jp/images/pagetop.png" />
</a></div>


<script type="text/javascript" class="microad_blade_track">
  <!--
  var microad_blade_jp = microad_blade_jp || { 'params' : new Array(), 'complete_map' : new Object() };
  (function() {
    var param = {'co_account_id' : '21878', 'group_id' : '', 'country_id' : '1', 'ver' : '2.1.0'};
    microad_blade_jp.params.push(param);

    var src = (location.protocol == 'https:')
      ? 'https://d-cache.microad.jp/js/blade_track_jp.js' : 'http://d-cache.microad.jp/js/blade_track_jp.js';

    var bs = document.createElement('script');
    bs.type = 'text/javascript'; bs.async = true;
    bs.charset = 'utf-8'; bs.src = src;

    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(bs, s);
  })();
  -->
</script>


</body>
</html>


## 入力

```
```

## 出力

```
```

## 気づいたこと
