import { createApp } from 'vue'
import { Quasar } from 'quasar'
import quasarLang from 'quasar/lang/en-US'

import App from './pages/IndexPage.vue'

import '@quasar/extras/material-icons/material-icons.css'
import 'quasar/src/css/index.sass'

createApp(App)
  .use(Quasar, {
    lang: quasarLang
  })
  .mount('#app')