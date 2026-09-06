# 問題メモ

- 問題URL:
- ランク:
- 制限: 5.0 秒 / 512 MB

## 入力

ページのソースを以下にコピペ。


<!DOCTYPE html>
<html lang='ja'>
<head>

<meta charset="utf-8">
<title>A097:絵の具配合システムの問題に再チャレンジ！ | ITエンジニア専門の転職サイト【paiza転職】</title>
<link rel="icon" type="image/x-icon" href="/favicon.ico">
<link rel="icon" type="image/svg+xml" href="/favicon.svg">
<meta name="description" content="A097:絵の具配合システムの問題の再チャレンジページです。GLHF｜プログラミング問題を解くと企業からスカウトが届くコーディング転職サイト【paiza転職】">
<meta property="og:title" content="A097:絵の具配合システムの問題に再チャレンジ！">
<meta property="og:image" content="https://paiza.jp/images/ogp/og_paiza_career.png">
<meta property="og:type" content="company">
<meta property="og:url" content="https://paiza.jp/challenges/918/retry">
<meta property="og:site_name" content="A097:絵の具配合システムの問題に再チャレンジ！">
<meta property="og:description" content="A097:絵の具配合システムの問題の再チャレンジページです。GLHF｜プログラミング問題を解くと企業からスカウトが届くコーディング転職サイト【paiza転職】">
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
<link rel="stylesheet" href="https://paiza.jp/assets/challenges-a2b92d090ed4f0c6f56bc8d19fb1c49ad2d6d7c16430ca7f1e1e34da61f5dce6.css" />
<link rel="stylesheet" href="https://paiza.jp/assets/common/editor-f6a7169c2cd59d32f92702bb3a9f631737b4a8d1a04562902ef558b7191d13de.css" />
<link rel="stylesheet" href="https://paiza.jp/assets/skillcheck/sample-122f945221f40ef12a168d6253b6ad56914cbb2aaf0d808cebf566d9cf0c643e.css" />
<script src="https://cdn-paiza.paiza.jp/packs/vendor/deprecated/ace.ad29aaa114f561ef.js" defer="defer"></script>
<script src="https://paiza.jp/assets/challenges/editor-bcfc24a5bc89e34d147a09e3582fa349d02ac5cae3de105af24499248b84b257.js" defer="defer"></script>
<script src="https://cdn-paiza.paiza.jp/packs/partials/commons/challenge_compile_and_test.2e7a040705eb71c7.js" defer="defer"></script>
<script src="https://cdn-paiza.paiza.jp/packs/partials/commons/challenge_code_submit.3f70cefbd215ae02.js" defer="defer"></script>

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
<meta name="csrf-token" content="a38ASEynUBRYS_Lg6fQuI9A0GOUwtRyDD9-l7y6nPat1jeTCLXi1DhflacuL5GSIADJHL5hBq8AshQ9BKbMxaw" />
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
<div data-display-menu='true' data-enable-learning-path='false' data-is-agent-scouts-badge-visible='false' data-is-bookmarks-badge-visible='true' data-is-display-scout-config='false' data-is-entries-badge-visible='false' data-is-messages-badge-visible='false' data-is-mypage-badge-visible='false' data-is-student='false' data-is-study-group-user='false' data-is-target-of-plan-after-graduation='false' data-logged-in='true' data-new-graduates-target-year='' id='js-react-global-header'></div>


<noscript>
<p style='text-align:center;'>javascriptを有効にして下さい。</p>
</noscript>
<div class='disnon' data-status='2000' id='user_info'></div>
<div class='text-center pc-only' id='pagebody'>
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
<textarea name="submit_code" id="submit_code" style="display: none">
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(&quot; &quot;);
        int T_R = int.Parse(arr[0]);
        int T_G = int.Parse(arr[1]);
        int T_B = int.Parse(arr[2]);

        int N = int.Parse(Console.ReadLine());

        List&lt;int&gt; reds = new List&lt;int&gt;();
        List&lt;int&gt; greens = new List&lt;int&gt;();
        List&lt;int&gt; blues = new List&lt;int&gt;();
        for (int i = 0; i &lt; N; i++) {
           string[] line = Console.ReadLine().Split(&quot; &quot;);
           reds.Add(int.Parse(line[0]));
           greens.Add(int.Parse(line[1]));
           blues.Add(int.Parse(line[2]));
        }

        int redsSum = reds[0];
        int greensSum = greens[0];
        int bluesSum = blues[0];
        for (int i = 1; i &lt; N; i++)
        {
            int nowCount = i + 1;

            // int同士の除算は自動で小数点切り捨てされるのでこれでOK
            redsSum += reds[i];
            int nowRedsAverage = redsSum / nowCount;

            greensSum += greens[i];
            int nowGreensAverage = greensSum / nowCount;

            bluesSum += blues[i];
            int nowBluesAverage = bluesSum / nowCount;

            if (
                nowRedsAverage == T_R &amp;&amp;
                nowGreensAverage == T_G &amp;&amp;
                nowBluesAverage == T_B
            )
            {
                Console.WriteLine(&quot;Yes&quot;);
                return;
            }
        }

        Console.WriteLine(&quot;No&quot;);
    }
}
</textarea>
<input type="hidden" name="submit_programming_language_id" id="submit_programming_language_id" value="2307" autocomplete="off" />
<input type="hidden" name="problem_rank_id" id="problem_rank_id" value="1801" autocomplete="off" />
<div class='boxSkillcheck mb5'>
<div class='d-problem'>
<h1 class='d-problem__page-title'>再チャレンジ A097:絵の具配合システム</h1>
</div>
<div id='tab-problem'>
<div class='d-problem-content'>
<div class='section3'>
<div class='d-problem-content__background-top'>
<div class='d-problem-content__background-bottom'>
<h2 class='d-problem-content__problem-title code3'>
<span class='d-problem-content__problem-title-background'>A097:絵の具配合システム</span>
</h2>
<div class="inr1">
    <p class="mb15">
あなたは、美術教室の絵の具在庫管理システムの開発を担当しています。この教室では、生徒が指定された色を作るために、複数の絵の具を混ぜる課題がよく出されます。<br/>
<br/>
絵の具を混ぜる際の規則は以下の通りです：<br/>
・任意の種類の絵の具を選んで混ぜる<br/>
・混ぜた色の RGB 値は、選んだ絵の具の各 RGB 成分の平均値となる<br/>
・平均値に小数部分が生じた場合は、小数点以下を切り捨てて整数にする<br/>
<br/>
例えば、赤 (255, 0, 0) と青 (0, 0, 255) を混ぜると：<br/>
・R = (255 + 0) / 2 = 127.5 → 127 (小数点以下切り捨て)<br/>
・G = (0 + 0) / 2 = 0<br/>
・B = (0 + 255) / 2 = 127.5 → 127 (小数点以下切り捨て)<br/>
・結果: (127, 0, 127) の紫色になります<br/>
<br/>
同様に、赤 (255, 0, 0)、緑 (0, 255, 0)、青 (0, 0, 255) の 3 色を混ぜると：<br/>
・R = (255 + 0 + 0) / 3 = 85.0 → 85<br/>
・G = (0 + 255 + 0) / 3 = 85.0 → 85<br/>
・B = (0 + 0 + 255) / 3 = 85.0 → 85<br/>
・結果: (85, 85, 85) のグレーになります<br/>
<br/>
生徒から「この色を作りたいのですが、手元にある絵の具で作れますか？」という質問をよく受けます。あなたの仕事は、与えられた絵の具のセットから、目標の色を作ることができるかを判定するプログラムを作成することです。<br/>
<br/>
入力例 1 の場合、以下のようになります。<br/>
<br/>
4 種類の絵の具があります：<br/>
1. (100, 50, 200)<br/>
2. (200, 100, 50)<br/>
3. (50, 200, 100)<br/>
4. (150, 150, 150)<br/>
<br/>
目標の色は (116, 116, 116) です。<br/>
<br/>
絵の具 1、2、3 を選んで混ぜると (絵の具 4 は使わない):<br/>
・R = (100 + 200 + 50) / 3 = 350 / 3 = 116.666... → 116 (小数点以下切り捨て)<br/>
・G = (50 + 100 + 200) / 3 = 350 / 3 = 116.666... → 116 (小数点以下切り捨て)<br/>
・B = (200 + 50 + 100) / 3 = 350 / 3 = 116.666... → 116 (小数点以下切り捨て)<br/>
<br/>
結果は (116, 116, 116) となり、目標の色と一致するため "Yes" を出力します。<br/>
<p><img alt="入力例 1" src="https://paiza.s3.amazonaws.com/problem/img/918/img.png" /></p>
</p>



</div>
  <div class="inr2">
    <div class="box2">
      <dl class="txt1">
      <dt class="icon1">評価ポイント</dt>
      <dd>
      10個のテストケースを入力し、正答数と解答の提出までに要した時間を測定し得点が決まります。 <br />
      ※提出いただいたコードは複数回実行され、一度の実行では1つのテストケースのみ入力<br />
      ※制限時間を超えるとテストケースが通っても失格(0点)となります。<br />
      得点の計算方法：正解数得点(50点) ＋ 正解率×解答時間得点(2時間以内で50点、4時間以内で25点、6時間で0点と線形に点数が落ちます)<br />
      <ol>
      <li>10個のテストケースで正しい出力がされるか評価 (50点)</li>
      <li>解答の提出までに要した時間による評価 (50点)</li>
      </ol>
      </dd>
      </dl>
    </div>
    <div class="box3">
      <dl class="txt1">
      <dt class="icon2">入力される値</dt>
      <dd>入力は次のフォーマットで与えられます。<br /></dd>
    <div class="box1">
      <dl class="txt2">
    <dd>T_R T_G T_B<br/>
N<br/>
R_1 G_1 B_1<br/>
R_2 G_2 B_2<br/>
...<br/>
R_N G_N B_N</dd>
      </dl>
    </div>
<br />
・1 行目には、目標の色の RGB 値 (T_R, T_G, T_B) が空白区切りで与えられます。<br/>
・2 行目には、使用可能な絵の具の種類数 N が与えられます。<br/>
・続く N 行には、各絵の具の RGB 値が空白区切りで与えられます。<br/>
　・R_i は i 番目の絵の具の赤成分<br/>
　・G_i は i 番目の絵の具の緑成分<br/>
　・B_i は i 番目の絵の具の青成分<br/>
・入力は合計で N+2 行からなり、入力値最終行の末尾に改行が 1 つ入ります。<br/>
<br />
  文字列は標準入力から渡されます。<a class="targetBlank" href="/guide/samplecode.html" target="_blank">標準入力からの値取得方法はこちらをご確認ください</a>
      </dd>
      </dl>
    </div>
    <div class="box3">
      <dl class="txt1">
      <dt class="icon3">期待する出力</dt>
与えられた絵の具を使って目標の色を作ることができる場合は "Yes"、できない場合は "No" を出力してください。<br/>
<br/>
末尾に改行を入れ、余計な文字、空行を含まないでください。<br/>
</dd>

        </dl>
    </div>

    <div class="box3">
      <dl class="txt1">
      <dt class="icon4">条件</dt>
      <dd>すべてのテストケースにおいて、以下の条件をみたします。</dd>
      <dd>・1 ≤ N ≤ 15</dd>
      <dd>・0 ≤ R_i, G_i, B_i ≤ 255 (各絵の具の RGB 値)</dd>
      <dd>・0 ≤ T_R, T_G, T_B ≤ 255 (目標の RGB 値)</dd>
      <dd>・全ての値は整数</dd>
      <br />
      言語別実行時間制限の詳細は
      <a href="/guide/language.html" target="_blank">
      こちら
      </a>
      をご確認ください。
      </dd>
      </dl>
    </div>
  </div>
<div class='sample-container'>
<div class="sample-content"><div class="sample-content__title">入力例1</div><pre class="sample-content__input"><code>116 116 116
4
100 50 200
200 100 50
50 200 100
150 150 150
</code></pre></div><div class="sample-content"><div class="sample-content__title">出力例1</div><pre class="sample-content__input"><code>Yes
</code></pre></div>
<div class="sample-content"><div class="sample-content__title">入力例2</div><pre class="sample-content__input"><code>0 255 0
2
255 0 0
0 0 255
</code></pre></div><div class="sample-content"><div class="sample-content__title">出力例2</div><pre class="sample-content__input"><code>No
</code></pre></div>
<div class="sample-content"><div class="sample-content__title">入力例3</div><pre class="sample-content__input"><code>130 110 140
4
120 80 200
180 120 60
60 180 120
200 60 180
</code></pre></div><div class="sample-content"><div class="sample-content__title">出力例3</div><pre class="sample-content__input"><code>No
</code></pre></div>



</div>
</div>
</div>
</div>
</div>
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
<input type="hidden" name="recovery_key" id="recovery_key" value="918" autocomplete="off" />
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
<option value="2325">Kotlin</option>
<option value="2312">Haskell(Beta)</option>
<option value="2313">CoffeeScript(Beta)</option>
<option value="2314">Bash(Beta)</option>
<option value="2315">Erlang(Beta)</option>
<option value="2316">R(Beta)</option>
<option value="2318">COBOL(Beta)</option>
<option value="2319">VB(Beta)</option>
<option value="2320">F#(Beta)</option>
<option value="2322">Clojure(Beta)</option>
<option value="2323">D(Beta)</option>
<option value="2326">Elixir(Beta)</option>
<option value="2327">Rust(Beta)</option>
<option value="2328">Scheme(Beta)</option></select>
</div>
</div>
<form class="simple_form new_retry_result" id="code_hand_in" novalidate="novalidate" action="/challenges/918/retry_submit" accept-charset="UTF-8" method="post"><input type="hidden" name="authenticity_token" value="C155BgQus8W_LDGOk168jrJg11Rs_mZdd6Tgwzv6UGWr5TuncrbjPFLLUKVMmAlA0_5SRO2-WZPCt-YHtGV4iQ" autocomplete="off" /><input id="programming_language_id" autocomplete="off" type="hidden" name="retry_result[programming_language_id]" />
<input id="code" autocomplete="off" type="hidden" name="retry_result[code]" />
</form><div class='editor_wrap'>
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
<button name="button" type="submit" id="do_compile" onclick="compile_ang_test(&#39;/challenges/918/compile_and_test&#39;)" class="btn btn-primary m-r-5"><span aria-hidden='true' class='p-challenges-icon p-challenges-icon--gear'></span>
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
<a id="handin" onclick="remove_stored_history(); hand_in_code(true);" class="btn btn-warning btn-lg m-r-5" href="javascript:void(0)">コードを提出する
</a></p>
</div>

</div>
</div>
</div>

</div>
<script src="https://cdn-paiza.paiza.jp/packs/partials/footers/global_footer.17b8eb89cd34d5a6.js" defer="defer"></script>
<link rel="stylesheet" href="https://cdn-paiza.paiza.jp/packs/partials/footers/global_footer.fc8919272cf72136.css" />

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


## 出力

```
```

## 気づいたこと
