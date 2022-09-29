import{d as b,u as g,o as _,a as n,c as o,b as d,t as l,e as u,F as h,r as f,f as e,g as m,h as x}from"./index.36a69966.js";import{_ as y}from"./Info.c36c2ed2.js";const $={key:0},k={class:"card shadow border-0 rounded-0 mb-3"},v={class:"card-body"},C={class:"d-flex flex-column flex-md-row"},N={class:"col"},S={class:"fw-bold sans tag bg-dark text-light rounded text-uppercase d-inline me-2"},W={key:0,class:"fw-bold sans tag bg-dark text-light rounded text-uppercase d-inline"},L=e("i",{class:"bi bi-radioactive text-warning rounded"},null,-1),V=m(" nuclear "),w=[L,V],B={class:"card-title w-max",style:{"margin-left":"-2px"}},F=["onClick"],M=e("i",{class:"bi bi-pencil"},null,-1),T=[M],D=["onClick"],K=e("i",{class:"bi bi-trash3"},null,-1),E=[K],R={class:"card-text text-army-500 pt-3 custom-class"},A=b({setup(j){const s=g();s.$patch({selectedFilterTypeKey:"weapon"}),_(()=>s.loadSoldiers()),_(()=>s.loadWeapons());function p(a){let{range:r,length:t,mass:c}=a,i=[];return i.push({title:"Range",info:`${r} m`}),i.push({title:"Length",info:`${t} m`}),i.push({title:"Mass",info:`${c} Kg`}),i}return(a,r)=>(n(),o(h,null,[d(s).filteredWeapons.length===0?(n(),o("h1",$,l(d(s).isLoading?"Loading":`No ${String(a.$route.name)}`),1)):u("",!0),(n(!0),o(h,null,f(d(s).filteredWeapons,t=>(n(),o("div",k,[e("div",v,[e("div",C,[e("div",N,[e("div",S,l(t.weaponType.name),1),t.isNuclear?(n(),o("div",W,w)):u("",!0),e("h2",B,[m(l(t.name)+" ",1),e("button",{type:"button",onClick:c=>a.$router.push(`/weapons/edit/${t.id}`),class:"btn btn-sm btn-outline-army-500 me-1"},T,8,F),e("button",{type:"button",onClick:c=>d(s).deleteWeapon(t.id),class:"btn btn-sm btn-outline-danger mx-1"},E,8,D)]),e("p",R,l(t.description),1)]),x(y,{details:p(t)},null,8,["details"])])])]))),256))],64))}});export{A as default};
