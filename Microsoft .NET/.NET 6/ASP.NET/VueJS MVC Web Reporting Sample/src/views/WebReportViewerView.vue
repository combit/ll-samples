<template>
    <div class="WebReportViewer">
        <WebReportViewer />
    </div>
</template>

<script>// @ is an alias to /src
import WebReportViewer from '@/components/WebReportViewer.vue'

export default {
  name: 'WebReportViewerView',
  components: {
    WebReportViewer
  },
      mounted() {
            let wrvScript = document.createElement('script')
            wrvScript.setAttribute('src', 'https://localhost:5011/WebReportViewer.js')
            document.head.appendChild(wrvScript)
        },
}</script>
