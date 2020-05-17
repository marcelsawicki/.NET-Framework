/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/main.ts");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./src/api.ts":
/*!********************!*\
  !*** ./src/api.ts ***!
  \********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
eval("\r\nObject.defineProperty(exports, \"__esModule\", { value: true });\r\nvar model_1 = __webpack_require__(/*! ./model */ \"./src/model.ts\");\r\nvar GitHubAPI = /** @class */ (function () {\r\n    function GitHubAPI() {\r\n    }\r\n    GitHubAPI.prototype.getListOfMembers = function () {\r\n        var _this = this;\r\n        return fetch(\"http://jsonplaceholder.typicode.com/posts\")\r\n            .then(function (response) { return _this.checkStatus(response); })\r\n            .then(function (response) { return _this.parseJSON(response)\r\n            .then(function (response) { return Promise.resolve(_this.mapGitHubMembersToMemberEntityCollection(response)); })\r\n            .catch(function (error) { return _this.throwError(error); }); });\r\n    };\r\n    GitHubAPI.prototype.getListOfMembersSpecified = function (idNumber) {\r\n        var _this = this;\r\n        return fetch(\"http://jsonplaceholder.typicode.com/posts/\" + idNumber.toString())\r\n            .then(function (response) { return _this.checkStatus(response); })\r\n            .then(function (response) { return _this.parseJSON(response)\r\n            .then(function (response) { return Promise.resolve(_this.mapGitHubMembersToMemberEntityCollectionSpecified(response)); })\r\n            .catch(function (error) { return _this.throwError(error); }); });\r\n    };\r\n    GitHubAPI.prototype.getListOfMembersByUserId = function (userNumber) {\r\n        var _this = this;\r\n        return fetch(\"http://jsonplaceholder.typicode.com/posts?userId=\" + userNumber.toString())\r\n            .then(function (response) { return _this.checkStatus(response); })\r\n            .then(function (response) { return _this.parseJSON(response)\r\n            .then(function (response) { return Promise.resolve(_this.mapGitHubMembersToMemberEntityCollection(response)); })\r\n            .catch(function (error) { return _this.throwError(error); }); });\r\n    };\r\n    GitHubAPI.prototype.checkStatus = function (response) {\r\n        if (response.status >= 200 && response.status < 300) {\r\n            return Promise.resolve(response);\r\n        }\r\n        else {\r\n            var error = new Error(response.statusText);\r\n            throw error;\r\n        }\r\n    };\r\n    GitHubAPI.prototype.parseJSON = function (response) {\r\n        return response.json();\r\n    };\r\n    GitHubAPI.prototype.mapGitHubMembersToMemberEntityCollection = function (data) {\r\n        var members;\r\n        members = data.map(function (gitHubMember) {\r\n            var member = new model_1.MessageEntity(gitHubMember);\r\n            return member;\r\n        });\r\n        return members;\r\n    };\r\n    GitHubAPI.prototype.mapGitHubMembersToMemberEntityCollectionSpecified = function (data) {\r\n        var members;\r\n        var member = new model_1.MessageEntity(data);\r\n        return member;\r\n    };\r\n    GitHubAPI.prototype.throwError = function (error) {\r\n        document.write(\"<p>Ops! something wrong! We are so embarrased..</p>\");\r\n        console.log(error);\r\n        return Promise.reject(error);\r\n    };\r\n    return GitHubAPI;\r\n}());\r\nexports.gitHubAPI = new GitHubAPI();\r\n\n\n//# sourceURL=webpack:///./src/api.ts?");

/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
eval("\r\nObject.defineProperty(exports, \"__esModule\", { value: true });\r\nvar api_1 = __webpack_require__(/*! ./api */ \"./src/api.ts\");\r\n// gitHubAPI.getListOfMembers()\r\n//   .then(\r\n//   (members: Array<MessageEntity>) => {\r\n//       displayMembers(members);\r\n//     }\r\n//   )\r\n//   .catch((err) => {\r\n//     document.write(\"Server error\");\r\n//   });\r\n// gitHubAPI.getListOfMembersSpecified(2)\r\n// .then(\r\n//   (member:MessageEntity) => {\r\n//     document.write(`<p>${member.userId}</p>`);\r\n//     document.write(`<p>${member.id}</p>`);\r\n//     document.write(`<p>${member.title}</p>`);\r\n//     document.write(`<p>${member.body}</p>`);\r\n//     }\r\n//   )\r\n//   .catch((err) => {\r\n//     document.write(\"Server error\");\r\n//   });\r\napi_1.gitHubAPI.getListOfMembersByUserId(2)\r\n    .then(function (members) {\r\n    displayMembers(members);\r\n})\r\n    .catch(function (err) {\r\n    document.write(\"Server error\");\r\n});\r\nfunction displayMembers(members) {\r\n    document.write(\"<span>Zadanie 1: pobrac dane (JSON), wyswietlic i renderowac za pomoca Mustache </span>\");\r\n    document.write(\"<p><b>Got this data from JSON:</b></p>\");\r\n    members.forEach(function (member) {\r\n        document.write(\"<p>\" + member.userId + \"</p>\");\r\n        document.write(\"<p>\" + member.id + \"</p>\");\r\n        document.write(\"<p>\" + member.title + \"</p>\");\r\n        document.write(\"<p>\" + member.body + \"</p>\");\r\n    });\r\n}\r\n\n\n//# sourceURL=webpack:///./src/main.ts?");

/***/ }),

/***/ "./src/model.ts":
/*!**********************!*\
  !*** ./src/model.ts ***!
  \**********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
eval("\r\nObject.defineProperty(exports, \"__esModule\", { value: true });\r\nvar MessageEntity = /** @class */ (function () {\r\n    function MessageEntity(gitHubMember) {\r\n        this.userId = gitHubMember.userId;\r\n        this.id = gitHubMember.id;\r\n        this.title = gitHubMember.title;\r\n        this.body = gitHubMember.body;\r\n    }\r\n    return MessageEntity;\r\n}());\r\nexports.MessageEntity = MessageEntity;\r\n\n\n//# sourceURL=webpack:///./src/model.ts?");

/***/ })

/******/ });