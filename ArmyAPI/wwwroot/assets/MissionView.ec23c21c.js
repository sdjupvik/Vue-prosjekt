import{d as g,u as y,o as C,a as i,c as l,b as c,t as r,e as w,F as u,r as h,f as t,g as p,h as $}from"./index.36a69966.js";import{_ as k}from"./Info.c36c2ed2.js";const v={key:0},M={class:"card shadow border-0 rounded-0 mb-3"},N={class:"card-body"},S={class:"d-flex flex-column flex-md-row"},D={class:"col"},L={class:"fw-bold sans tag bg-dark text-light rounded text-uppercase",style:{}},F={class:"card-title w-max",style:{"margin-left":"-2px"}},T=["onClick"],V=t("i",{class:"bi bi-pencil"},null,-1),B=[V],O=["onClick"],q=t("i",{class:"bi bi-trash3"},null,-1),E=[q],I=t("h6",{class:"card-title ps-0 w-max",hidden:""},[p(" Commanded by "),t("span",{class:"card-text text-army-500 fw-bolder"},"Major Tom Cruise")],-1),K={class:"card-text text-army-500 pt-3 custom-class"},j=t("h6",{class:"card-title ps-0 w-max fs-5 mb-0"}," Soldiers ",-1),P={class:"card-text text-army-500 fw-lighter me-3"},G=g({setup(R){const n=y();n.$patch({selectedFilterTypeKey:"mission"}),C(()=>n.loadMissions());function m(s){return s?Intl.DateTimeFormat("nb").format(new Date(s)):""}function f(s){let{planningStartedOn:_,missionCompletedOn:e,casualityCount:o,lossOfLifeCount:b,equipmentRepairCost:x,missionStatusId:d}=s,a=[];return a.push({title:"Planning",info:m(_)}),(d===3||d===4)&&a.push({title:"Completed",info:m(e)}),(d===2||d===3||d===4)&&(a.push({title:"Casualities",info:o}),a.push({title:"Loss of life",info:b}),a.push({title:"Equipment damage",info:`Kr ${x}`})),a}return(s,_)=>(i(),l(u,null,[c(n).filteredMissions.length===0?(i(),l("h1",v,r(c(n).isLoading?"Loading":`No ${String(s.$route.name)}`),1)):w("",!0),(i(!0),l(u,null,h(c(n).filteredMissions,e=>(i(),l("div",M,[t("div",N,[t("div",S,[t("div",D,[t("div",L,r(e.missionStatus.name),1),t("h2",F,[p(r(e.name)+" ",1),t("button",{type:"button",onClick:o=>s.$router.push(`/missions/edit/${e.id}`),class:"btn btn-sm btn-outline-army-500 me-1"},B,8,T),t("button",{type:"button",onClick:o=>c(n).deleteMission(e.id),class:"btn btn-sm btn-outline-danger mx-1"},E,8,O)]),I,t("p",K,r(e.description),1),t("div",null,[j,(i(!0),l(u,null,h(e.soldiers,o=>(i(),l("span",P,r(o.firstName)+" "+r(o.lastName),1))),256))])]),$(k,{details:f(e)},null,8,["details"])])])]))),256))],64))}});export{G as default};
