$(document).ready(function () {
    var a = "https://skin.1yyg.com";
    var b = $.cookie("isCookie");
    if (b == null || b != "yes") {
        alert("温馨提示：您的浏览器当前不支持Cookies功能，请您启用浏览器Cookie功能或更换浏览器。"); return
    }
    var c = "";
    var d = function () {
        var w = $("#j-tips-wrap");
        var ad = /\w+(@{1})$/i, q = ["qq.com", "vip.qq.com", "sina.com", "foxmail.com", "139.com", "sohu.com"], K = "", G = 0;
        var aa = function (ah) {
            var ag = function (ak, al, ai) {
                var aj = new RegExp(al, "g"); return ak.replace(aj, ai)
            };
            var ah = escape(ah);
            ah = ag(ah, "\\+", "%2B");
            ah = ag(ah, "/", "%2F");
            return ah
        };
        var M = function (ag) {
            var ah = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
            return ah.test(ag)
        };
        var y = function (ag) {
            var ah = /^.*@(vip.)?(163|126|yeah)\.(com|net)$/;
            return ah.test(ag)
        };
        var Q = function (ah) {
            var ag = /^(?![A-z]+$)(?!\d+$)(?![\W_]+$)^.{8,20}$/; return ag.test(ah)
        };
        var j = function (ah) {
            var ag = /^1\d{10}$/; return ag.test(ah)
        };
        var U = function (ah, ag) {
            $.PageDialog('<div class="mAltFail"><s></s>' + ah + "</div>", { W: 300, H: 60, close: false, autoClose: true, submit: function () { if (ag) { ag() } } })
        };
        var I = function (ah, ag) {
            $.PageDialog('<div class="mAltOK"><s></s>' + ah + "</div>", { W: 300, H: 60, close: false, autoClose: true, submit: function () { if (ag) { ag() } } })
        };
        var v = function () {
            try {
                if (_IsIE && _IeVersion == 6) {
                    Base.getScript(a + "/JS/iepng.js?date=20150215", function () {
                        if (EvPNG != null && EvPNG != undefined) {
                            EvPNG.fix(".transparent-png")
                        }
                    })
                }
            }
            catch (ag) { }
        };
        var R = $("#txtUserName");
        var r = $("#txtPwd");
        var z = $("#txtConPwd");
        var D = $("#txtCode");
        var J = $("#imgCode");
        var p = "", S = "", Z = "", t = "";
        var H = function (ag, ah) {
            O(ag);
            if ($(ag).siblings(".orange").length > 0) {
                $(ag).parent().addClass("error-text");
                $(ag).siblings(".orange").html('<i class="passport-icon transparent-png"></i>' + ah).show(5, function () { v() })
            } else {
                $(ag).parent().parent().addClass("error-text");
                $(ag).parent().next(".orange").html('<i class="passport-icon transparent-png"></i>' + ah).show(5, function () { v() })
            }
            if ($(ag).val() == "") {
                $(ag).siblings("em").hide()
            }
            e = false
        };
        var W = function (ag) {
            if ($(ag).siblings(".orange").length > 0) { $(ag).parent().removeClass("error-text"); $(ag).siblings(".orange").hide() } else { $(ag).parent().parent().removeClass("error-text"); $(ag).parent().next(".orange").hide() }
        };
        var i = function (ag) {
            W(ag);
            $(ag).parent().removeClass("enter-focus").addClass("correct-text");
            $(ag).siblings("s.passport-icon").show()
        };
        var O = function (ag) {
            $(ag).parent().removeClass("correct-text");
            $(ag).siblings("s.passport-icon").hide()
        };
        var N = function (ag) {
            var ah = $("#regVcCodeLi");
            ah.addClass("error-text");
            ah.children("span").html('<i class="passport-icon transparent-png"></i>' + ag).show();
            setTimeout(function () { h() }, 3000); e = false
        };
        var h = function () {
            var ag = $("#regVcCodeLi"); ag.removeClass("error-text"); ag.children("span").hide()
        };
        var k = null;
        var ab = "";
        var ac = function () {
            this.checkUserName = function (ah, ag) { p = R.val().trim(); if (p == "") { if (ah) { R.focus() } H(R, "请输入您的手机号/邮箱地址"); ab = ""; return false } else { if (!j(p) && !M(p)) { if (ah) { R.focus() } H(R, "请输入正确的手机号或邮箱地址"); ab = ""; return false } else { if (y(p)) { if (ah) { R.focus() } H(R, "很抱歉，暂不支持此类邮箱，建议您使用QQ邮箱或手机号"); ab = ""; return false } else { if (ag && (p != ab)) { ab = p; k = setTimeout(function () { GetJPData("", "checkname", "name=" + p, function (ai) { V = true; T = ai.state; if (ai.state == 0) { i(R) } else { H(R, '账号已注册，请更换或<a href="login.html?account=' + escape(p) + '" class="blue">立即登录</a>') } }) }, 200); return false } } } } return true }; this.checkPwd = function (ag) { S = r.val().trim(); if (S == "") { if (ag) { r.focus() } H(r, "请设置登录密码"); return false } else { if (!Q(S)) { if (ag) { r.focus() } H(r, "密码由8-20位字母、数字或符号两种或以上组合"); return false } else { i(r) } } return true }; this.checkConPwd = function (ag) { S = r.val().trim(); Z = z.val().trim(); if (Z == "") { if (ag) { z.focus() } H(z, "请输入确认密码"); return false } else { if (!Q(Z)) { if (ag) { z.focus() } H(z, "密码由8-20位字母、数字或符号两种或以上组合"); return false } else { if (S != Z) { if (ag) { z.focus() } H(z, "两次输入的密码不一致"); return false } else { i(z) } } } return true }; this.checkCode = function (ah) { var ag = /^[0-9A-Za-z]{4,6}$/; t = D.val().trim(); if (t == "") { if (ah) { D.focus() } H(D, "请输入验证码"); return false } else { if (!ag.test(t)) { if (ah) { D.focus().select() } H(D, "验证码输入有误"); return false } else { i(D) } } return true }
        };
        var B = new ac();
        R.focus(function () {
            $(this).parent().addClass("enter-focus"); $(this).siblings("em").html("推荐使用手机号注册")
        }).blur(function () {
            $(this).parent().removeClass("enter-focus");
            if ($(this).val() == "") {
                $(this).siblings("em").html("手机号/邮箱地址").show();
                $(this).css("color", "#bbbbbb");
                W($(this)); O($(this));
                return
            } B.checkUserName(false, true)
        }).click(function (ag) {
            ag = ag || window.event; ag.stopPropagation(); if (w.children().length > 0 && R.val().indexOf("@") !== -1) { w.show() }
        }).keydown(function () {
            $(this).css("color", "#333333");
            $(this).siblings("em").hide();
            W($(this)); O($(this))
        }).keyup(function () {
            var ag = $(this).val().trim();
            if (ag != "") {
                if (ag != ab) {
                    V = false; T = -1
                }
            }
        });
        if (R.val() == "") {
            R.siblings("em").bind("click", function () {
                R.focus()
            }).show()
        }
        R.keyup(function (an) {
            an = an || window.event;
            an.stopPropagation();
            var ah = this.value, al = 0, ak = 0, am = q.length, ag = an.keyCode, ai = "";
            if (ad.test(ah)) {
                for (; al < am; al++) {
                    K += "<li class='j-tips'>" + (ah + q[al]) + "</li>"
                }
                w.show().empty().html(K);
                K = ""
            } else {
                if (ah.indexOf("@") !== -1) {
                    var ao = ah.indexOf("@"), aj = ah.slice(0, ao + 1), aq = ah.slice(ao + 1);
                    for (; ak < am; ak++) {
                        if (q[ak].indexOf(aq) !== -1) { ai += "<li class='j-tips'>" + (aj + q[ak]) + "</li>" }
                    } if (ai !== "") {
                        w.show().empty().html(ai)
                    } else {
                        w.hide(); G = 0
                    }
                } else {
                    G = 0;
                    w.hide()
                }
            }
            if (w.css("display") === "block") {
                var ap = w.find("li");
                switch (ag) {
                    case 13: if (G > 0) {
                        R.val(ap.eq(G - 1).text().trim()); w.hide(); B.checkUserName(false, true); G = 0
                    }
                        break;
                    case 40: G = G + 1 > ap.length ? 1 : G + 1;
                        ap.removeClass("selected").eq(G - 1).addClass("selected");
                        break;
                    case 38: G = G - 1 < 1 ? ap.length : G - 1;
                        ap.removeClass("selected").eq(G - 1).addClass("selected");
                        break;
                    default: break
                }
            }
        });
        w.click(function (ah) {
            ah = ah || window.event;
            ah.stopPropagation();
            var ag = ah.target || ah.srcElement;
            if (ag.tagName.toLowerCase() === "li") {
                R.val($(ag).text().trim());
                B.checkUserName(false, true)
            }
            $(this).hide()
        });
        $(window).click(function (ah) {
            if (w.css("display") !== "block") {
                return
            }
            ah = ah || window.event;
            var ag = ah.target || ah.srcElement, ai = ag.id.toLowerCase();
            if (ai !== "j-tips-wrap" || ai !== "txtUserName") {
                w.hide()
            }
        }); r.focus(function () {
            $(this).parent().addClass("enter-focus");
            $(this).siblings("em").html("8-20位字母、数字或符号两种或以上组合");
            w.hide()
        }).blur(function () {
            $(this).parent().removeClass("enter-focus");
            if ($(this).val() == "") {
                $(this).siblings("em").html("设置登录密码").show();
                $(this).css("color", "#bbbbbb");
                W($(this));
                O($(this));
                return
            }
            B.checkPwd(false);
            $("#pwdStrength").hide()
        }).keydown(function () {
            $(this).css("color", "#333333");
            $(this).siblings("em").hide();
            W($(this));
            O($(this))
        }).bind("keyup", function () {
            ae($(this).val())
        });
        if (r.val() == "") {
            r.siblings("em").bind("click", function () {
                r.focus()
            }).show()
        } z.focus(function () {
            $(this).parent().addClass("enter-focus");
            w.hide()
        }).blur(function () {
            $(this).parent().removeClass("enter-focus");
            if ($(this).val() == "") {
                $(this).siblings("em").show();
                $(this).css("color", "#bbbbbb");
                W($(this));
                O($(this));
                return
            }
            B.checkConPwd(false)
        }).keydown(function () {
            $(this).css("color", "#333333");
            $(this).siblings("em").hide();
            W($(this));
            O($(this))
        });
        if (z.val() == "") {
            z.siblings("em").bind("click", function () {
                z.focus()
            }).show()
        }
        var af = $("#dragBtn");
        var f = $("#dragBtnLeft");
        var o = $("#dragBtnContainer");
        var Y = $("#canvasContainer");
        var F = $("#vcCanvas");
        var L = $("#regVcCodeLi");
        var X = 338;
        var n = 132;
        var s = o.outerWidth();
        var E = af.outerWidth();
        var g = false;
        var m = false;
        var C = true;
        af.draggable({
            containment: "#dragBtnContainer",
            start: function () {
                if (C === false) { return false } if (!B.checkUserName(true, false)) { return false } h()
            },
            drag: function (ah, ai) {
                var ag = ai.position.left; f.css("width", ag + "px")
            },
            stop: function (ah, ai) {
                var ag = ai.position.left; if (ag < s - E) { af.animate({ left: "0" }); f.animate({ width: "0" }) } else { _NameVal = $("#txtUserName").val(); GetJPData("https://passport.1yyg.com", "getVcChar", "key=" + _NameVal, function (aj) { if (aj.state == 1) { l(); $(".canvas-wrapper").hide(); N("请求验证码太频繁，请稍后再试"); return false } else { if (aj.state == 0) { var ak = aj.str; $("#selectedChar").text(ak); o.children(".vc-slide-text").hide(); o.children(".vc-slideBtnLeft").find("span:eq(1)").hide(); o.children(".vc-slideBtnLeft").find("span:eq(0),a").show(); Y.parent().show(); Y.css("height", n + "px"); af.css({ "float": "left", left: ag + "px" }); af.children("i").removeClass("ready-status vali-status wrong-status right-status").addClass("vali-status"); F.attr("src", "https://passport.1yyg.com/api/GetVcImg.html?" + x(ak)); C = false; m = false } } }) }
            }
        });
        function l() {
            f.css("width", "0");
            af.animate({ left: "0" }); o.children(".vc-slide-text").show(); o.children(".vc-slideBtnLeft").find("span:eq(1)").hide(); o.children(".vc-slideBtnLeft").find("span:eq(0),a").hide(); C = true; m = false; af.children("i").removeClass("ready-status vali-status wrong-status right-status").addClass("ready-status")
        }
        function A() {
            var ag = R.val(); F.hide(); GetJPData("https://passport.1yyg.com", "getVcChar", "key=" + ag, function (ah) { if (ah.state == 1) { l(); $(".canvas-wrapper").hide(); N("请求验证码太频繁，请稍后再试"); return false } else { if (ah.state == 0) { var ai = ah.str; $("#selectedChar").text(ai); $("#dragBtnLeft").find(".span:eq(1)").hide(); $("#dragBtnLeft").find(".span:eq(0),a").show(); Y.parent().show(); Y.css("height", n + "px"); F.attr("src", "https://passport.1yyg.com/api/GetVcImg.html?" + x(ai)).show() } } })
        }
        function x(ah) {
            var ag = "width=" + X + "&height=" + n + "&selectedChar=" + ah; return ag
        }
        var u = $("#refreshVcCode");
        var P = null;
        u.click(function () {
            if (P != null) { console.log("too fast！！"); return } P = setTimeout(function () { P = null }, 200); af.children("i").removeClass("ready-status vali-status wrong-status right-status").addClass("vali-status"); A()
        });
        F.click(function (ai) {
            var ah = F.offset().left; var ak = F.offset().top; var ag = ai.pageX - ah; var aj = ai.pageY - ak; GetJPData("https://passport.1yyg.com", "VcCompare", "x=" + ag + "&y=" + aj, function (al) { if (al.state == 1) { if (al.num == 1) { af.children("i").attr("class", "passport-icon wrong-status"); A(); return false } else { l(); $(".canvas-wrapper").hide(); N("请求验证码太频繁，请稍后再试"); return false } } else { if (al.state == 0) { c = al.str; m = true; $("#dragBtnLeft").find("span:eq(0),a").hide(); $("#dragBtnLeft").find("span:eq(1)").show(); af.children("i").attr("class", "passport-icon right-status"); Y.parent().hide() } } })
        });
        var ae = function (ah) {
            var ai = $("#pwdStrength"); var ak = ["", '<p class="orange" ><strong>安全强度：</strong><cite><dfn style="width:33.33%;"></dfn></cite>弱</p>', '<p class="yellow" ><strong>安全强度：</strong><cite><dfn style="width:66.66%;"></dfn></cite>中</p>', '<p class="green" ><strong>安全强度：</strong><cite><dfn style="width:100%;"></dfn></cite>强</p>']; var ag = function (al) { ai.html(ak[al]).show() }; var aj = function (al) { if (al.length >= 8) { if (/[a-zA-Z]+/.test(al) && /[0-9]+/.test(al) && /[^A-Za-z0-9]+/.test(al)) { ag(3) } else { if (/[a-zA-Z]+/.test(al) && /[0-9]+/.test(al)) { ag(2) } else { if (/[a-zA-Z]+/.test(al) && /[^A-Za-z0-9]+/.test(al)) { ag(2) } else { if (/[0-9]+/.test(al) && /[^A-Za-z0-9]+/.test(al)) { ag(2) } else { ag(1) } } } } } else { ag(0) } }; aj(ah)
        };
        var e = false; var V = false; var T = -1; $("#btnAgreeBtn").bind("click", function () { if (e) { return } e = true; if (k != null) { clearTimeout(k) } if (!B.checkUserName(true, false)) { return } var ag = $(this); var ah = function (aj) { if (aj == 0) { i(R); if (!B.checkPwd(true) || !B.checkConPwd(true)) { return } if (m === false) { N("请按住滑块，拖动到最右边"); return false } ag.addClass("letter-noSpac").html("正在提交，请稍候..."); var ai = "account=" + p + "&pwd=" + aa(S) + "&auth=" + c; GetJPData("", "saveregsiter", ai, function (ak) { if (ak.state == 0) { location.replace("registercheck.html?str=" + ak.str + "&forward=" + aa($("#hidRegisterForward").val())) } else { if (ak.state == 1 && ak.num == -101) { U("很抱歉，暂不支持此类邮箱，建议您使用QQ邮箱或手机号") } else { if (ak.state == 1 && ak.num == 2) { U("操作太频繁，请稍后再试！", function () { location.reload() }) } else { if (ak.state == -6) { U("验证码错误，请重新验证！", function () { location.reload() }) } else { U("注册失败，请重试！", function () { location.reload() }) } } } } }) } else { H(R, '账号已注册，请更换或<a href="login.html?account=' + escape(p) + '" class="blue">立即登录</a>'); R.focus() } }; if (V) { ah(T) } else { GetJPData("", "checkname", "name=" + p, function (ai) { V = true; T = ai.state; ah(ai.state) }) } }); $("div.register-form-con").keydown(function (ah) { var ag = (window.event) ? event.keyCode : ah.keyCode; if (ag == 32) { return false } else { if (ag == 13) { $("#btnAgreeBtn").trigger("click") } } return true })
    };
    Base.getScript(a + "/JS/AjaxFun.js?date=20130123", d)
});